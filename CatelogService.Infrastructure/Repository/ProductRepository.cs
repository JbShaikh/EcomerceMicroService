

using CatelogService.Application.Interfaces;
using CatelogService.Domain.Entities;
using CatelogService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatelogService.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatelogDbContext db;
        public ProductRepository(CatelogDbContext context) {
            this.db = context;
        }

        public async Task<List<Product>> GetAll() {
            return await db.Products.ToListAsync();
        }
        public async Task<Product> GetById(int id) {
            return await db.Products.FindAsync(id);
        }
        public async Task Add(Product product) {
            db.Products.AddAsync(product);
            await db.SaveChangesAsync();
        }
        public async Task Update(Product product) {
            db.Products.Update(product);
            await db.SaveChangesAsync();
        }
        public async Task Delete(Product product) { 
        db.Products.Remove(product);
            await db.SaveChangesAsync();
        }
        
            
    }
}
