
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Domain.Entities;
namespace OrderService.Application.Interfaces
{
    public interface ICartRepository
    {
        public Task<Cart> GetCartByCustomerId(int customerId);
        public Task Add(Cart cart);
        public Task Update(Cart cart);
        public Task Delete(Cart cart);
        public Task<CartItem> GetCartItemById(int id);
        public Task RemoveCartItem(CartItem item);
    }
}
