using AutoMapper;
using CatelogService.Application.DTOs.StockInventry;
using CatelogService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ecommerce.Application.Mapping
{
    public class StockTransectionProfile : Profile
    {
        public StockTransectionProfile() {

            CreateMap<StockTransection, StockTransectionDTOs>()
                .ForMember(
               dest => dest.ProductName,
               opt => opt.MapFrom(src => src.Product.Name));
        }
    }
}
