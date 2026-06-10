
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Interfaces
{
    public interface ICoupanRepository
    {
        Task<List<Coupan>> GetAll();
        Task<Coupan> GetById(int id);
        Task Add(Coupan cpn);
        Task Update(Coupan cpn);
        Task Delete(Coupan cpn);
        Task<Coupan> GetByCode(string code); 
    }
}
