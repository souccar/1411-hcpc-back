using Abp.Application.Services.Dto;
using Souccar.Hcpc.Products.Dto.Products;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestProducts
{
    public class OutputRequestProductDto: EntityDto<int>
    {
        public int OutputRequestId { get; set; }
        public int CanProduce { get; set; }
        public int ActualProduce { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
    }
}
