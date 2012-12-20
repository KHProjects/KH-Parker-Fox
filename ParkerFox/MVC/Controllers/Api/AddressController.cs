using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVC.Dto;

namespace MVC.Controllers.Api
{
    public class AddressController : ApiController
    {
        public IEnumerable<AddressLookup> Get(string id) //called id cos of mapping
        {
            return new List<AddressLookup>
                {
                    new AddressLookup {NameOrNumber = "100", Street = "Street one", PostCode = id},
                    new AddressLookup {NameOrNumber = "101", Street = "Street two", PostCode = id},
                    new AddressLookup {NameOrNumber = "102", Street = "Street three", PostCode = id}
                };
        }


    }
}
