using Abp.Application.Services.Dto;
using Souccar.Hcpc.Products.Dto.Products;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestProductDtos
{
    public class ReadOutputRequesProductDto : IEntityDto<int>
    {
        public int Id { get; set; }
        public int CanProduce { get; set; }
        public  ProductDto Product { get; set; }
    }
}
