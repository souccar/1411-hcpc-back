using Abp.Application.Services.Dto;
using Souccar.Hcpc.Products.Dto.Products;

namespace Souccar.Hcpc.DailyProductions.Dto.DailyProductionDetailsDtos
{
    public class ReadDailyProductionDetailsDto : EntityDto<int>
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public ReadProductDto Product { get; set; }
    }
}
