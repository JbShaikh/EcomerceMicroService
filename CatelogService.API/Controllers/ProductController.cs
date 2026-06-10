using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using CatelogService.Application.Interfaces;
using CatelogService.Application.DTOs.ProductDTOs;
using CatelogService.Domain.Entities;
namespace CatelogService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private readonly IProductRepository pr;
        private readonly IMapper mapper;
        public ProductController(IProductRepository pr,IMapper mapper, ILogger<ProductController> logger) {
            this.pr = pr;
            this.mapper = mapper;
            this.logger = logger;
        }

        
        [HttpGet("GetAll")]
        //public async Task<ActionResult> GetAll() { 
        //var data = await pr.GetAll();
        //return Ok(data);
        //}
        public async Task<ActionResult> GetAll()
        {
            logger.LogInformation("Fetching all products");
            var data = await pr.GetAll();
            var product = mapper.Map<List<ProductDTO>>(data);
            return Ok(product);
        }
        [HttpGet("TestException")]
        public ActionResult TestException()
        {
            throw new Exception("Custom Exception Generated");
            return Ok();
        }

        [HttpGet("ById/{id}")]
        //public async Task<ActionResult> GetById(int id) { 
        //var data = await pr.GetById(id);
        //    if (data == null) {
        //        return NotFound();
        //    }
        //    return Ok(data);
        //}
        public async Task<ActionResult> GetById(int id)
        {
            var data = await pr.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            var product = mapper.Map<ProductDTO>(data);
            return Ok(product);
        }
        [HttpPost("add")]
        //public async Task<ActionResult> Add(Product product) { 
        //await pr.Add(product);
        //    return Ok("Product Addes");
        //}
        public async Task<ActionResult> Add(CreateProductDTO dto)
        {
            var product = mapper.Map <Product> (dto);
            await pr.Add(product);
            return Ok("Product Addes");
        }
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(int id, UpdateProductDTO productdto)
        {
            var data = await pr.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            mapper.Map(productdto, data);
            await pr.Update(data);
            return Ok("Updated Successfully");
        }
        //public async Task<ActionResult> Update(int id, Product product) {
        //    var data = await pr.GetById(id);
        //    if (data == null) {
        //        return NotFound();
        //    }
        //    data.Name = product.Name;
        //    data.Price = product.Price;
        //    data.Stock = product.Stock;
        //    data.Description = product.Description;
        //    await pr.Update(data);
        //    return Ok("Updated Successfully");
        //}
        [HttpDelete("delete/id")]
        public async Task<ActionResult> Delete(int id) {
            var data = await pr.GetById(id);
            if (data == null) {
                return NotFound();
            }
            await pr.Delete(data);
            return Ok("Deleted Successfully");
        
        }
        

    }
}
