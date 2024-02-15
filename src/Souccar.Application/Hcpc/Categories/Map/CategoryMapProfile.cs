using AutoMapper;
using Souccar.Hcpc.Products.Dto.Formulas;
using Souccar.Hcpc.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Souccar.Hcpc.Categories.Dto;

namespace Souccar.Hcpc.Categories.Map
{
    public class CategoryMapProfile : Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, UpdateCategoryDto>();
            CreateMap<CategoryDto, ReadCategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<CategoryDto, UpdateCategoryDto>();
        }
    }
}
