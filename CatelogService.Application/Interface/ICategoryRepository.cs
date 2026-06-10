using CatelogService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatelogService.Application.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAll();
        public Task<Category> GetById(int id);
        public Task Add(Category cat);
        public Task Update(Category cat);
        public Task Delete(Category cat);
    }
}
