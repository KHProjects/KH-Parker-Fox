using System.Linq;
using ParkerFox.Core.ApplicationServices;
using ParkerFox.Core.Entities.Ecommerce;
using ParkerFox.Core.Entities.Repository;
using ParkerFox.Infrastructure.Data;
using System.Collections.Generic;

namespace ParkerFox.Application
{
    public sealed class CartServices : ICartServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartItemRepository _cartItemRepository;

        private List<CartItem> _cartItems = new List<CartItem>
            {
                new CartItem {Product = new Product {Name = "product one"}, Quantity = 1},
                new CartItem {Product = new Product {Name = "product two"}, Quantity = 1},
                new CartItem {Product = new Product {Name = "product three"}, Quantity = 1},
                new CartItem {Product = new Product {Name = "product four"}, Quantity = 1}
            };

        public CartServices(IUnitOfWork unitOfWork, ICartItemRepository cartItemRepository)
        {
            _unitOfWork = unitOfWork;
            _cartItemRepository = cartItemRepository;
        }

        public IEnumerable<CartItem> GetCurrentItems()
        {
            return _cartItems;
            //return _cartItemRepository.GetCurrent("").All();
        }

        public void AddItem(CartItem cartItem)
        {
            _cartItemRepository.Add(cartItem);
            _unitOfWork.Commit();
        }

        public void UpdateItem(CartItem itemUpdate)
        {
            var cartItem = _cartItems.FirstOrDefault(c => c.Product.ProductId == itemUpdate.Product.ProductId);
            if (cartItem == null)
                _cartItems.Add(cartItem);
            else
                cartItem.Quantity = itemUpdate.Quantity;
        }

        public void RemoveItem(int productId)
        {
            var cartItem = _cartItems.FirstOrDefault(c => c.Product.ProductId == productId);
            if (cartItem != null)
                _cartItems.Remove(cartItem);
        }
    }
}
