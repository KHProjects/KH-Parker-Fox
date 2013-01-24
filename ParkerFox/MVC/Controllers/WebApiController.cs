using MVC.Components;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC.Controllers
{
    public class WebApiController : ApiController
    {
        public IEnumerable<Customer> Get()
        {
            return new[]
                {
                    new Customer {FirstName = "Dean"},
                    new Customer {FirstName = "Sebastian"},
                    new Customer {FirstName = "Left4bed"},
                    new Customer {FirstName = "Mana Monkey"},
                    new Customer {FirstName = "Nathan"},
                    new Customer {FirstName = "Daniel"}
                };
        }

        // GET api/webapi/5
        public Customer Get(int id)
        {
            return new Customer {FirstName = String.Format("with id {0}", id)};
        }

        // POST api/webapi
        public void Post([FromBody]string value)
        {
        }

        // PUT api/webapi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/webapi/5
        public void Delete(int id)
        {
        }
    }
}
