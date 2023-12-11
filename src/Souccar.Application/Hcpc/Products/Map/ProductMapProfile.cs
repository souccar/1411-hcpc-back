using AutoMapper;
using Souccar.Hcpc.Products.Dto.Products;
using Souccar.Hcpc.Products.Dto.Products.OutputRequestProductDtos;

namespace Souccar.Hcpc.Products.Map
{
    public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Product, OutputRequestProductDto>();
            CreateMap<OutputRequestProductDto, Product>();
            CreateMap<Product, ProductOfMaterialDto>();
            CreateMap<Product, ReadProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, UpdateProductDto>();
        }
    }
}
