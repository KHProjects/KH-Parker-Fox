
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http;
using Dapper;
using MagHag.Subscriptions.Core.ReadModel;

namespace MagHag.ReadStore.Api
{
    public class PublicationController : ApiController
    {
        public IEnumerable<ActivePublication> Get()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MagHag.ReadStore"].ConnectionString))
            {
                connection.Open();
                return connection.Query<ActivePublication>("SELECT * FROM dbo.ActivePublication");
            }
        }

        public void Post(ActivePublication activePublication)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MagHag.ReadStore"].ConnectionString))
            {
                connection.Open();
                connection.Execute("INSERT dbo.ActivePublication VALUES(@PublicationId, @Title)", activePublication);
            }
        }
    }
}
