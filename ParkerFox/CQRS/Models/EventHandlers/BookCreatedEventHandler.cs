using CQRS.Models.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlServerCe;
using System.Linq;
using System.Web;

namespace CQRS.Models.EventHandlers
{
    public class BookCreatedEventHandler : IHandleEvent<BookCreated>
    {
        public void Handle(BookCreated bookCreated)
        {
            string sql = "INSERT Book(Title) VALUES(@Title)";
            using(SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["main"].ConnectionString))
            using(SqlCeCommand command = new SqlCeCommand(sql, connection))
            {
                command.Parameters.Add("@Title", bookCreated.Title);

                connection.Open();
                command.ExecuteNonQuery();
            }

        }
    }
}