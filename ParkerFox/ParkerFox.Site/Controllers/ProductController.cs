using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ParkerFox.Site.ViewModels;

namespace ParkerFox.Site.Controllers
{
    public class ProductController : ApiController
    {
        public ProductViewModel Get(int id)
        {
            if (id == 1)
            {
                return new ProductViewModel { Name = "product one" };
            }

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }
}
