
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
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
    public  class CustomerRepository:ICustomerRepository
    {
        private readonly OrderDbContext db;
        public CustomerRepository(OrderDbContext context)
        {

            this.db = context;
        }
        public async Task<List<Customer>> GetAll() {
            return await db.Customers.ToListAsync();       
        }
        public async Task<Customer> GetById(int id) {
            return await db.Customers.FindAsync(id);
        }
        public async Task Add(Customer cust) {
            db.Customers.AddAsync(cust);
            await db.SaveChangesAsync();
        }
        public async Task Update(Customer cust) {
            db.Customers.Update(cust);
            await db.SaveChangesAsync();
        }
        public async Task Delete(Customer cust)
        {
            db.Customers.Remove(cust);
            await db.SaveChangesAsync();
        }

    }
}
