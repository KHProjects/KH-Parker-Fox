using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ParkerFox.Core.Entities.Ecommerce;
using ParkerFox.Core.Entities.Repository;

namespace ParkerFox.WebApi.Ecommerce
{
    public class ProductController : ApiController
    {
        private readonly IProductRepository _products;

        public ProductController(IProductRepository products)
        {
            _products = products;
        }

        public IEnumerable<Product> Get()
        {
            return _products.GetOnPromotion().All();
        }

        public Product Get(int id)
        {
            return _products.GetById(id);
        }

        public HttpResponseMessage Put(Product product)
        {
            Request.CreateResponse(HttpStatusCode.Accepted, product);
            return null;
        }

        public HttpResponseMessage Delete(int id)
        {
            return null;
        }

        public IEnumerable<Product> Find(string queryText)
        {
            return new List<Product>();
        }
    }
}
