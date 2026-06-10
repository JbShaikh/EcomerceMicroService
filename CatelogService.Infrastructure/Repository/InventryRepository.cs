
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
    public class InventryRepository : IInventryRepository
    {
        private readonly CatelogDbContext db;
        public InventryRepository(CatelogDbContext db) {

            this.db = db;

        }
        public async Task IncreaseStock(int productId, int quantity) {

            var product = await db.Products.FindAsync(productId);
            if (product == null) {
                throw new Exception("Not FOund");
            }
            product.Stock += quantity;
            await db.StockTransections.AddAsync(
                new StockTransection
                {
                    ProductId = productId,
                    Quantity = quantity,
                    TransectionType = "Added",
                    CreateDate = DateTime.Now
                }
                );
            await db.SaveChangesAsync();
        }
        public async Task DecreaseStock(int productId, int quantity) {
            var product = await db.Products.FindAsync(productId);
            if (product == null) {
                throw new Exception("Product not Fount");
            }
            product.Stock -= quantity;
            await db.StockTransections.AddAsync(
                new StockTransection
                {
                    ProductId = productId,
                    Quantity = quantity,
                    TransectionType = "Sold",
                    CreateDate = DateTime.Now
                }
                );
            await db.SaveChangesAsync();
        
        }
        public async Task<List<StockTransection>> GetHistory() {
            return await db.StockTransections.Include(x => x.Product).ToListAsync();
        }

    }
}

