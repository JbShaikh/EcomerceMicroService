

using Microsoft.EntityFrameworkCore;
using OrderService.Application.Interfaces;
using OrderService.Domain.Entities;
using OrderService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly OrderDbContext db;
        public CartRepository(OrderDbContext db) { 
        this.db = db;
        }
        public async Task<Cart> GetCartByCustomerId(int customerId) 
        {
            return await db.Carts
                    .Include(x => x.CartItems)
                    .ThenInclude(x => x.ProductName)
                    .FirstOrDefaultAsync(x => x.CustomerId == customerId);
        }
        public async Task Add(Cart cart) {
            db.Carts.AddAsync(cart);
            await db.SaveChangesAsync();
        }
        public async Task Update(Cart cart) {
            db.Carts.Update(cart);
            await db.SaveChangesAsync();
        }
        
        public async Task<CartItem> GetCartItemById(int id) {
            return await db.CartItems.FirstOrDefaultAsync(x => x.Id == id);
        }
        //Cart Item Deletion, means Delete Product from Cart
        public async Task RemoveCartItem(CartItem item) {
             db.CartItems.Remove(item);
            await db.SaveChangesAsync();
        }
        //Cart Deleteion
        public async Task Delete(Cart cart)
        {
            db.Carts.Remove(cart);
            await db.SaveChangesAsync();
        }
    }
}
