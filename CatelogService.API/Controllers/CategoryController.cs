using AutoMapper;
using CatelogService.Application.DTOs.CategoryDTOs;
using CatelogService.Application.Interfaces;
using CatelogService.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;

namespace CatelogService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository cat;
        private readonly IMapper mapper;
        public CategoryController(ICategoryRepository cat, IMapper mapper   )
        {
            this.cat = cat;
            this.mapper = mapper;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllCategories() {
            var data = await cat.GetAll();
            var catData = mapper.Map<List<CategoryDTO>>(data);
            return Ok(catData);
        }
        [HttpGet("GetBy/{id}")]
        public async Task<IActionResult> GetCategoryById(int id) {
            var data = await cat.GetById(id);
            if (data == null) {
                return NotFound();
            }
            var databyid = mapper.Map<CategoryDTO>(data);
            return Ok(databyid);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddCategory(CreateCategoryDTO catagory) {
            var data = mapper.Map<Category>(catagory);
            await cat.Add(data);
            return Ok("Data Added Successfully");
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO upcat, int id) {
            var data = await cat.GetById(id);
            if (data == null) {
                return NotFound();
            }
            var dataUpdate = mapper.Map(upcat, data);
            await cat.Update(dataUpdate);
            return Ok("Updated Succefully");
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCategory(int id) { 
        var data = await cat.GetById(id);
            if (data == null) {
                return NotFound();
            }
           await cat.Delete(data);
            return Ok("Data Deleted Succeffully");
        }

    }
}
