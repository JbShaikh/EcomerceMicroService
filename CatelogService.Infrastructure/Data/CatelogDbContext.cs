
using CatelogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatelogService.Infrastructure.Data
{
    public class CatelogDbContext : DbContext
    {
        public CatelogDbContext(DbContextOptions<CatelogDbContext>options) : base(options) {
        
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<StockTransection> StockTransections { get; set; }
        
    }
}
