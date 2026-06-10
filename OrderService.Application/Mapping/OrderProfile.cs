using AutoMapper;
using OrderService.Application.DTOs.Order;
using OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderDTO, Order>();

            CreateMap<OrderItemDTO, OrderItem>();

            CreateMap<OrderItem, OrderItemDTO>();

            CreateMap<UpdateOrderDTO, Order>();

            CreateMap<Order, OrderDTO>();
        }
    }
}
