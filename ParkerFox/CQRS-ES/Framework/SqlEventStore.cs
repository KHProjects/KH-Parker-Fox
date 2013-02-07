using System.Data.SqlServerCe;
using System.Threading;
using System.Transactions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CQRS_ES.Framework
{
    public class SqlEventStore : IEventStore
    {
        private readonly MessageBus _bus;

        public SqlEventStore(MessageBus bus)
        {
            _bus = bus;
        }

        public void StoreEvents(object streamId, IEnumerable<object> events, long expectedInitialVersion)
        {
            events = events.ToArray();

            var connectionString = ConfigurationManager.ConnectionStrings["main"].ConnectionString;
            var serializedEvents =
                events.Select(x => new Tuple<string, string>(x.GetType().FullName, JsonConvert.SerializeObject(x)));

            using (var connection = new SqlCeConnection(connectionString))
            {
                connection.Open();

                const string commandText = "SELECT TOP 1 CurrentSequence FROM Streams WHERE StreamId = @StreamId;";
                long? existingSequence;
                using (var command = new SqlCeCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("StreamId", streamId.ToString());
                    var current = command.ExecuteScalar();
                    existingSequence = current == null ? (long?) null : (long) current;

                    if (existingSequence != null && ((long) existingSequence) > expectedInitialVersion)
                        throw new ConcurrencyException();
                }

                using (var transaction = new TransactionScope())
                {
                    var nextVersion = InsertEventsAndReturnLastVersion(streamId, connection, expectedInitialVersion,
                                                                       serializedEvents);
                    if(existingSequence == null)
                        StartNewSequence(streamId, nextVersion, connection);
                    else
                    {
                        UpdateSequence(streamId, expectedInitialVersion, nextVersion, connection);
                    }
                    transaction.Complete();
                }
            }

            _bus.Publish(events);
        }

        public IEnumerable<object> LoadEvents(object id, long version = 0)
        {
            const string commandText =
                "SELECT EventType, Body FROM EventWrappers WHERE StreamId = @StreamId AND Sequence >= @Sequence ORDER BY TimeStamp;";
            var connectionString = ConfigurationManager.ConnectionStrings["main"].ConnectionString;

            using(var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(commandText, connection))
            {
                command.Parameters.AddWithValue("StreamId", id.ToString());
                command.Parameters.AddWithValue("Sequence", version);

                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var eventTypeString = reader["EventType"].ToString();
                    var eventType = Type.GetType(eventTypeString);
                    var body = reader["Body"].ToString();
                    yield return JsonConvert.DeserializeObject(body, eventType);
                }
            }
        }

        public IEnumerable<object> GetAllEventsEver()
        {
            const string cmdText = "SELECT EventType, BODY from EventWrappers ORDER BY TimeStamp";
            var connectionString = ConfigurationManager.ConnectionStrings["main"].ConnectionString;
            using (var con = new SqlCeConnection(connectionString))
            using (var cmd = new SqlCeCommand(cmdText, con))
            {
                cmd.Connection.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var eventTypeString = reader["EventType"].ToString();
                    var eventType = Type.GetType(eventTypeString);
                    var serializedBody = reader["Body"].ToString();
                    yield return JsonConvert.DeserializeObject(serializedBody, eventType);
                }
            }
        }

        private long InsertEventsAndReturnLastVersion(object streamId, SqlCeConnection connection, long nextVersion,
                                                      IEnumerable<Tuple<string, string>> serializedEvents)
        {
            foreach (var @event in serializedEvents)
            {
                const string insertCommandText = "INSERT INTO EventWrappers (EventId, StreamId, Sequence, TimeStamp, EventType, Body) VALUES (@EventId, @StreamId, @Sequence, @TimeStamp, @EventType, @Body);";
                using (var command = new SqlCeCommand(insertCommandText, connection))
                {
                    command.Parameters.AddWithValue("EventId", Guid.NewGuid());
                    command.Parameters.AddWithValue("StreamId", streamId.ToString());
                    command.Parameters.AddWithValue("Sequence", ++nextVersion);
                    command.Parameters.AddWithValue("TimeStamp", DateTime.UtcNow);
                    command.Parameters.AddWithValue("EventType", @event.Item1);
                    command.Parameters.AddWithValue("Body", @event.Item2);

                    command.ExecuteNonQuery();
                }
            }
            return nextVersion;
        }

        private void StartNewSequence(object streamId, long nextVersion, SqlCeConnection connection)
        {
            const string commandText =
                "INSERT INTO Streams (StreamId, CurrentSequence) VALUES (@StreamId, @CurrentSequence);";
            using (var command = new SqlCeCommand(commandText, connection))
            {
                command.Parameters.AddWithValue("StreamId", streamId.ToString());
                command.Parameters.AddWithValue("CurrentSequence", nextVersion);

                var rows = command.ExecuteNonQuery();
                if (rows != 1)
                    throw new ConcurrencyException();
            }
        }

        private void UpdateSequence(object streamId, long expectedInitialVersion, long nextVersion, SqlCeConnection connection)
        {
            const string commandText =
                "UPDATE Streams SET CurrentSequence = @CurrentSequence WHERE StreamId = @StreamId AND CurrentSequence = @OriginalSequence;";
            using (var command = new SqlCeCommand(commandText, connection))
            {
                command.Parameters.AddWithValue("StreamId", streamId.ToString());
                command.Parameters.AddWithValue("CurrentSequence", nextVersion);
                command.Parameters.AddWithValue("OriginalSequence", expectedInitialVersion);

                var rows = command.ExecuteNonQuery();
                if(rows != 1)
                    throw new ConcurrencyException();
            }
        }
    }
}