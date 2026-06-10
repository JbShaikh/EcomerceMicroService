
using OrderService.Application.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Interfaces
{
    public interface ICatelogServiceClient
    {
        Task<ProductDtos?> GetProductById(int productId);
    }
}
