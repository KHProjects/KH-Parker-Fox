using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace CQRS.Models.Data
{
    public class SqlServerEventStore : IEventStore
    {
        private BinaryFormatter _serializer = new BinaryFormatter();

        public void Persist(IAggregateRoot aggregateRoot)
        {
            var sql = "INSERT [Event](AggregateId, Version, Data) VALUES(@AggregateId, @Version, @Data)";
            using(var connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString))
            using(var command = new SqlCeCommand(sql, connection))
            {
                command.Parameters.Add("@AggregateId", aggregateRoot.Id);
                command.Parameters.Add("@Version", aggregateRoot.Version);
                command.Parameters.Add("@Data", Serialize(aggregateRoot.UncommitedEvents));

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<IEventInputStream> Load(Guid aggregateId)
        {
            throw new NotImplementedException();
        }

        private byte[] Serialize(IEnumerable<IEvent> events)
        {
            using(var stream = new MemoryStream())
            {
                _serializer.Serialize(stream, events.ToArray());
                return stream.GetBuffer();
            }
        }
    }
}