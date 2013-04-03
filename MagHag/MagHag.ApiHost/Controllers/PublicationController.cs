using MagHag.ApiHost.Representations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MagHag.ApiHost.Controllers
{
    public class PublicationController : ApiController
    {
        public IEnumerable<Publication> Get()
        {
            using (var session = Program.GetDocumentStore().OpenSession())
            {
                return session.Query<Publication>().ToList();
            }
        }
    }
}
