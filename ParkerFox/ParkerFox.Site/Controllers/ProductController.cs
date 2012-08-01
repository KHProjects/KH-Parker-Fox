using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ParkerFox.Core.Entities.Ecommerce;
using ParkerFox.Core.Entities.Repository;
using ParkerFox.Site.ViewModels;
using ParkerFox.Site.ViewModels.Store;

namespace ParkerFox.Site.Controllers
{
    public class ProductController : ApiController
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> Get()
        {
            var product = _productRepository.GetOnPromotion();            
            return product.All();
        }

        public ProductViewModel Get(int id)
        {
            var product = _productRepository.GetById(id);

            if(product != null)
            {
                return new ProductViewModel
                    {
                        Name = product.Name
                    };
            }
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        public void Put(ProductViewModel product)
        {
            string name = product.Name;
        }

        public void Post(ProductViewModel productViewModel)
        {
            Product product = new Product {Name = productViewModel.Name};

            _productRepository.Add(product);
        }

        public IEnumerable<Product> InCategory(string category)
        {
            return new List<Product>();
        }
    }
}
