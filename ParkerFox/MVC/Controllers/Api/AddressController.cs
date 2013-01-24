using MVC.Dto;
using System.Collections.Generic;
using System.Web.Http;

namespace MVC.Controllers.Api
{
    public class AddressController : ApiController
    {
        public IEnumerable<AddressLookup> Get(string id) //called id cos of url mapping
        {
            return new List<AddressLookup>
                {
                    new AddressLookup {NameOrNumber = "100", Street = "Street one", PostCode = id},
                    new AddressLookup {NameOrNumber = "101", Street = "Street two", PostCode = id},
                    new AddressLookup {NameOrNumber = "102", Street = "Street three", PostCode = id}
                };
        }

        public override System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> ExecuteAsync(System.Web.Http.Controllers.HttpControllerContext controllerContext, System.Threading.CancellationToken cancellationToken)
        {
            return base.ExecuteAsync(controllerContext, cancellationToken);
        }
    }
}
