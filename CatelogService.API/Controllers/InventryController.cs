using AutoMapper;
using CatelogService.Application.DTOs.StockInventry;
using CatelogService.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatelogService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventryController : ControllerBase
    {
        private readonly IInventryRepository inventory;
        private readonly IMapper mapper;
        public InventryController(IInventryRepository inventory, IMapper mapper)
        {
            this.inventory = inventory;
            this.mapper = mapper;
        }
        [HttpPost("increase")]
        public async Task<IActionResult> IncreaseStocks(int productId, int quantity) { 
        await inventory.IncreaseStock(productId, quantity);
            return Ok("Inventry Stock Increased");
        }
        [HttpPost("decrease")]
        public async Task<IActionResult> DescreasedStock(int productId, int quantity) {
            await inventory.DecreaseStock(productId, quantity);
            return Ok("Inventry Stock Decreased");
        }
        [HttpGet("history")]
        public async Task<IActionResult> GetHistory() { 
        var history = await inventory.GetHistory();
            var data = mapper.Map<List<StockTransectionDTOs>>(history);
            return Ok(data);
        }
    }
}
