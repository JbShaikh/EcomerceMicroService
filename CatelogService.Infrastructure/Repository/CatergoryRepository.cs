
using CatelogService.Application.Interfaces;
using CatelogService.Domain.Entities;
using CatelogService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatelogService.Infrastructure.Repositories
{
    public class CatergoryRepository:ICategoryRepository
    {
        private readonly CatelogDbContext db;
        public CatergoryRepository(CatelogDbContext db) {
            this.db = db;
        }
        public async Task<List<Category>> GetAll() {
            return await db.Categories.ToListAsync();
        }
        public async Task<Category> GetById(int id) {
            return await db.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task Add(Category cat) {
             await db.AddAsync(cat);
            await db.SaveChangesAsync();
        }
        public async Task Update(Category cat) {
            db.Categories.Update(cat);
            await db.SaveChangesAsync();
        }
        public async Task Delete(Category cat) {
            db.Categories.Remove(cat);
            await db.SaveChangesAsync();
        }
    }
}
