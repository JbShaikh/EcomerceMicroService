using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.DTOs.Order;
using OrderService.Application.Interfaces;
using OrderService.Domain.Entities;

namespace OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAPIController : ControllerBase
    {
        private readonly IOrderRepository repo;
        private readonly IMapper mapper;
        private readonly ICatelogServiceClient _catelogServiceClient;
        public OrderAPIController(IOrderRepository repo, ICatelogServiceClient catelogServiceClient, IMapper mapper) 
        {
            this.repo = repo;
            this._catelogServiceClient = catelogServiceClient;

            this.mapper = mapper;
        }
        [HttpGet("All")]
        public async Task<ActionResult> GetAll() { 
        
            var data = await repo.GetAll();
            var ord = mapper.Map<List<OrderDTO>>(data);
            return Ok(ord);
        }
        [HttpGet("getBy{id}")]
        public async Task<ActionResult> GetOrderById(int id) {
            var data = await repo.GetById(id);
            if (data == null) {
                return NotFound();
            }
            var dt = mapper.Map<OrderDTO>(data);
            return Ok(dt);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> CreateOrder(CreateOrderDTO order) {

            var data = mapper.Map<Order>(order);
            data.OrderDate = DateTime.Now;
            decimal grandTotal = 0;
            foreach (var item in data.OrderItems)
            {
                var product =
                    await _catelogServiceClient.GetProductById(item.ProductId);

                if (product == null)
                {
                    return BadRequest(
                        $"Product {item.ProductId} not found");
                }

                item.ProductName = product.Name;

                item.Price = product.Price;

                item.TotalPrice =
                    product.Price * item.Quantity;

                grandTotal += item.TotalPrice;
            }
            data.TotalAmount = grandTotal;
            await repo.Add(data);
            return Ok("OrderCreated");
        
        }
        [HttpPut("Update")]
        public async Task<ActionResult> UpdateOrder(UpdateOrderDTO ord, int id) {
            var data = await repo.GetById(id);
            if (data == null) {
                return NotFound();
            }
            mapper.Map(ord, data);
            await repo.Update(data);
            return Ok("Order Updated SuccessFully");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id) {
            var data = await repo.GetById(id);
            if (data == null) {
                return NotFound();
            }
            await repo.Delete(data);
            return Ok("Order Deleted Successfully");
        }
    }
}
