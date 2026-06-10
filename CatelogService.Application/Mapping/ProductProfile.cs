
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CatelogService.Application.DTOs.ProductDTOs;
using CatelogService.Domain.Entities;

namespace Ecommerce.Application.Mapping
{
    public class ProductProfile : Profile{
        public ProductProfile() {
            CreateMap<CreateProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
        }
        
    }
}
