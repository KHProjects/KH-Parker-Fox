using ParkerFox.Core.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkerFox.Core.Entities.Ecommerce;
using ParkerFox.Core.Entities.Repository;

namespace ParkerFox.Application
{
    public sealed class CartServices : ICartServices
    {
        private readonly ICartItemRepository _cartItemRepository;
        private static List<CartItem> _cartItems = new List<CartItem>
            {
                new CartItem {Product = new Product {ProductId = 1, Name = "Product one"}, Quantity = 1},
                new CartItem {Product = new Product {ProductId = 2, Name = "Product two"}, Quantity = 1},
                new CartItem {Product = new Product {ProductId = 3, Name = "Product three"}, Quantity = 5}
            };

        public IEnumerable<CartItem> GetCurrentItems()
        {
            return _cartItems;
        }

        public void AddItem(CartItem cartItem)
        {
            _cartItems.Add(cartItem);
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
