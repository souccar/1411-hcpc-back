using AutoMapper;
using Souccar.Hcpc.Products.Dto.Products;

namespace Souccar.Hcpc.Products.Map
{
    public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Product, ReadProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, UpdateProductDto>();
        }
    }
}
