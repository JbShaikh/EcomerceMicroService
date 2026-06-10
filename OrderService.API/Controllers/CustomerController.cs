using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OrderService.Application.DTOs.CustomerDTOs;
using OrderService.Application.Interfaces;
using OrderService.Domain.Entities;
using System.Runtime.InteropServices;

namespace OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
       
        private readonly ICustomerRepository cust;
        private readonly IMapper mapper;
        public CustomerController(ICustomerRepository cust, IMapper mapper) { 
        this.cust = cust;
        this.mapper = mapper;
        }
        [HttpGet("Get")]
        //public async Task<ActionResult> GetAllCustomer() {
        //    var data = await cust.GetAll();
        //    return Ok(data);
        //}
        public async Task<ActionResult> GetAllCustomer()
        {
            var data = await cust.GetAll();
            var customers = mapper.Map<List<CustomerDTO>>(data);
            return Ok(customers);
        }
        [HttpGet("GetBy{id}")]
        //public async Task<ActionResult> GetCustomerById(int id) {
        //    var customer = await cust.GetById(id);
        //    if (customer == null) {

        //        return NotFound();
        //    }
        //    return Ok(customer);
        //}
        public async Task<ActionResult> GetCustomerById(int id)
        {
            var customer = await cust.GetById(id);
            if (customer == null)
            {

                return NotFound();
            }
          var ct = mapper.Map<CustomerDTO>(customer);
            return Ok(ct);
        }
        [HttpPost("Add")]
        //public async Task<ActionResult> AddCustomer(Customer cs) {

        //    await cust.Add(cs);
        //    return Ok("Added Successfully");
        //}

        public async Task<ActionResult> AddCustomer(CreateCustomerDTO cs)
        {
            var data = mapper.Map<Customer>(cs);
            await cust.Add(data);
            return Ok("Added Successfully");
        }
        [HttpPut("Update")]
        //public async Task<ActionResult> Update(int id, Customer c) {
        //    var data = await cust.GetById(id);
        //    if (data == null) {
        //        return NotFound();
        //    }
        //    data.Name = c.Name;
        //    data.Email = c.Email;
        //    data.Password= c.Password;
        //   await cust.Update(data);
        //    return Ok("Updated Successfully");
        //}
        public async Task<ActionResult> Update(int id, UpdateCustomerDTO c)
        {
            var data = await cust.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            mapper.Map(c, data);
            await cust.Update(data);
            return Ok("Updated Successfully");
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var cd = await cust.GetById(id);
            if (cd == null)
            {
                return NotFound();
            }
            await cust.Delete(cd);
            return Ok("Customer Deleted Succeffully");
        }
    }
}
