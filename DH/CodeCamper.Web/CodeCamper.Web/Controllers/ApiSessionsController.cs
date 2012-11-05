using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeCamper.Data;
using CodeCamper.Data.Contracts;
using CodeCamper.Model;

namespace CodeCamper.Web.Controllers
{
    public class ApiSessionsController : ApiControllerBase
    {

      public ApiSessionsController(ICodeCamperUow uow)
      {
        Uow = uow;
      }

        // GET api/sessions
        public IEnumerable<Session> Get()
        {
          return Uow.Sessions.GetAll().OrderBy(s => s.Id);
        }

        // GET api/sessions/5
        public Session Get(int id)
        {
          return Uow.Sessions.GetById(id);
        }

        // POST api/sessions
        public void Post([FromBody]string value)
        {
        }

        // PUT api/sessions/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/sessions/5
        public void Delete(int id)
        {
        }
    }
}
