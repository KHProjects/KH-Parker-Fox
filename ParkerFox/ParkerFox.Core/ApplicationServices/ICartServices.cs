using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkerFox.Core.Entities.Ecommerce;

namespace ParkerFox.Core.ApplicationServices
{
    public interface ICartServices
    {
        IEnumerable<CartItem> GetCurrentItems();
        void AddItem(CartItem cartItem);
        void UpdateItem(CartItem itemUpdate);
        void RemoveItem(int productId);
    }
}
