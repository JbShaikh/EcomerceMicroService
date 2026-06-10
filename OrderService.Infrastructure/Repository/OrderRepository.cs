
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using OrderService.Application.Interfaces;
using OrderService.Domain.Entities;
using OrderService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        private readonly OrderDbContext db;
       
        public OrderRepository(OrderDbContext db) { 
        this.db = db;
        
        }

        //public async Task<List<Order>> GetAll() {
        //    return await db.Orders.Include(x => x.OrderItems).ToListAsync();
        //}
        //public async Task<Order> GetById(int id) {
        //    return await db.Orders.Include(x => x.OrderItems).FirstOrDefaultAsync(x => x.Id == id);
        //}
        //public async Task Add(Order order) {
        //await db.Orders.AddAsync(order);
        //await db.SaveChangesAsync();
        //}
        public async Task<List<Order>> GetAll() {
           return await db.Orders.Include(x => x.OrderItems).Include(x => x.Customer).ToListAsync();
        }
        public async Task<Order> GetById(int id) {
            return await db.Orders.Include(x => x.OrderItems).Include(x => x.Customer).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task Add(Order order) { 
        await db.Orders.AddAsync(order);
        await db.SaveChangesAsync();
        }
        public async Task Update(Order order) {
            db.Orders.Update(order);
            await db.SaveChangesAsync();
        }
        public async Task Delete(Order order) {
            db.Orders.Remove(order);
            await db.SaveChangesAsync();
        }
    }
}
