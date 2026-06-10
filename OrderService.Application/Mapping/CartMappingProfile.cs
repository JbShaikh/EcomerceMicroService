using AutoMapper;
using OrderService.Application.DTOs.CartDTOs;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Mapping
{
    public class CartMappingProfile : Profile
    {
        public CartMappingProfile() {

            CreateMap<Cart, CartDTO>();
            CreateMap<CartItem, CartItemDTO>()
                .ForMember(
                dest => dest.ProductName,
                opt => opt.MapFrom(src => src.ProductName)
                );
            CreateMap<AddToCartDTO, Cart>();
            CreateMap<UpdatCartItemDTO, CartItem>();

        }
    }
}
