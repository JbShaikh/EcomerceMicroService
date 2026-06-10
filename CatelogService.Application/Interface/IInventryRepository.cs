
using CatelogService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatelogService.Application.Interfaces
{
    public interface IInventryRepository
    {
        Task IncreaseStock(int productId, int quantity);
        Task DecreaseStock(int productId, int quantity);
        Task <List<StockTransection>> GetHistory();
    }
}
