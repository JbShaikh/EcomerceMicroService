using AutoMapper;
using OrderService.Application.DTOs.CoupanDTOs;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Mapping
{
    public class CoupanMappingProfile : Profile
    {
        public CoupanMappingProfile() {
            CreateMap<CreateCoupanDTO, Coupan>();
            CreateMap<UpdateCoupanDTO, Coupan>();
            CreateMap<Coupan, CoupanDTO>();
        }
    }
}
