using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ParkerFox.Core.ApplicationServices;
using ParkerFox.WebApi.Ecommerce.Dto;
using ParkerFox.Core.Entities.Ecommerce;

namespace ParkerFox.WebApi.Ecommerce
{
    public class BasketController : ApiController
    {
        private readonly ICartServices _cartServices;

        public BasketController(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }

        public HttpResponseMessage Post(CartItem cartItem)
        {
            _cartServices.AddItem(cartItem);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage Put(int productId, BasketItem basketItem)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
