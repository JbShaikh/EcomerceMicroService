
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using OrderService.Application.Interfaces;
using OrderService.Domain.Entities;
using OrderService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Repositories
{
    public class CoupanRepository : ICoupanRepository
    {
        private readonly OrderDbContext db;
        public CoupanRepository(OrderDbContext db) { 
        this.db = db;
        }
        public async Task<List<Coupan>> GetAll() {
            return await db.Coupons.ToListAsync();
        }
        public async Task<Coupan> GetById(int id) {
            return await db.Coupons.FindAsync(id);
        }
        public async Task<Coupan> GetByCode(String code) {
            return await db.Coupons.FirstOrDefaultAsync(x => x.Code == code);
        }
        public async Task Add(Coupan cpn) {
            await db.Coupons.AddAsync(cpn);
            await db.SaveChangesAsync();
        }
        public async Task Update(Coupan cpn) {
            db.Coupons.Update(cpn);
            await db.SaveChangesAsync();
        }
        public async Task Delete(Coupan cpn) {
            db.Coupons.Remove(cpn);
            await db.SaveChangesAsync();
        }
    }
}
