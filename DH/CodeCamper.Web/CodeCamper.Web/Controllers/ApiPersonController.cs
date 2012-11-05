using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodeCamper.Data.Contracts;
using CodeCamper.Model;
using CodeCamper.ViewModels.Person;

namespace CodeCamper.Web.Controllers
{
  public class ApiPersonController : ApiControllerBase
    {

        public ApiPersonController(ICodeCamperUow uow)
        {
          Uow = uow;
        }

        // GET api/person
        public IEnumerable<Person> Get()
        {
          return Uow.PersonRepository.GetAll();
          
        }

        // GET api/person/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/person
        public void Post(RegisterViewModel registerViewModel)
        {
          Uow.PersonRepository.Add(new Person { FirstName = "test1", LastName = "test2" });
          Uow.Commit();
        }

        // PUT api/person/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/person/5
        public void Delete(int id)
        {
        }
    }
}
