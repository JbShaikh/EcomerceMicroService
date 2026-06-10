using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.DTOs.CoupanDTOs;
using OrderService.Application.Interfaces;
using OrderService.Domain.Entities;

namespace OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoupanController : ControllerBase
    {
        private readonly ICoupanRepository cp;
        private readonly IMapper mapper;
        public CoupanController(ICoupanRepository cp, IMapper mapper) {
            this.cp = cp;
            this.mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCoupan() {
            var coupans = await cp.GetAll();
            if (coupans == null) {
                return NotFound();
            }
            var cpMap = mapper.Map<List<CoupanDTO>>(coupans);
            return Ok(cpMap);
        }
        [HttpGet("GetBy{id}")]
        public async Task<IActionResult> GetCoupanById(int id) { 
        var coupan = await cp.GetById(id);
            if (coupan == null) {
                return NotFound();
            }
            var coupmapp = mapper.Map<CoupanDTO>(coupan);
            return Ok(coupmapp);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddCoupan(CreateCoupanDTO cpn) {
            var coupan = mapper.Map<Coupan>(cpn);
            coupan.IsActive = true;
            await cp.Add(coupan);
            return Ok("Coupan Added Successfully");
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCoupan(UpdateCoupanDTO ucpn, int id) {
            var cpData = await cp.GetById(id);
            if (cpData == null) {
                return NotFound();
            }
            mapper.Map(ucpn, cpData);
            await cp.Update(cpData);
            return Ok("Update Successfully");
        }
        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> DeleteCoupan(int id) { 
        var coupan = await cp.GetById(id);
            if (coupan == null) {
                return NotFound();
                }
            await cp.Delete(coupan);
            return Ok("Coupan Deleted");
        }

    }
}
