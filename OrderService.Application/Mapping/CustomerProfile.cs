using AutoMapper;
using OrderService.Application.DTOs.CustomerDTOs;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Mapping
{
    public class CustomerProfile : Profile
    {
     public CustomerProfile() {
            CreateMap<CreateCustomerDTO, Customer>();
            CreateMap<UpdateCustomerDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();
        }   
       
    }
}
