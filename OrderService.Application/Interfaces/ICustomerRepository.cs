
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<List<Customer>> GetAll();
        public Task<Customer> GetById(int id);
        public Task Add(Customer cust);
        public Task Update(Customer cust);
        public Task Delete(Customer cust);
    }
}
