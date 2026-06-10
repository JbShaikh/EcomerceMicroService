using AutoMapper;
using CatelogService.Application.DTOs.CategoryDTOs;
using CatelogService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatelogService.Application.Mapping
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile() {
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<UpdateCategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();
        
        }
    }
}
