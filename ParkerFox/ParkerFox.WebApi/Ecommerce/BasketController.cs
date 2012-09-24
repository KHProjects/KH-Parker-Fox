using ParkerFox.Core.ApplicationServices;
using ParkerFox.Core.Entities.Ecommerce;
using ParkerFox.WebApi.Ecommerce.Dto;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
