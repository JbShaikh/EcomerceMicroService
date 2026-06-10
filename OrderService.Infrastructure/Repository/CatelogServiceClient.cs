
using OrderService.Application.DTOs.Order;
using OrderService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CatelogService.Infrastructure.Repository
{
    public class CatelogServiceClient : ICatelogServiceClient
    {
        private readonly HttpClient _httpClient;
        public CatelogServiceClient(HttpClient httpCLient) {
            _httpClient = httpCLient;
        }
        public async Task<ProductDtos?> GetProductById(int productId) {
            return await _httpClient.GetFromJsonAsync<ProductDtos>($"api/Product/ById/{productId}");
        }
    }
}
