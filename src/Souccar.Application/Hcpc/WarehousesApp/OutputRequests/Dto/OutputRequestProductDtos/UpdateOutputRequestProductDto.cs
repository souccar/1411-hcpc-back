using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.WarehousesApp.Dto.OutputRequests.OutputRequestProductDtos
{
    public class UpdateOutputRequestProductDto : EntityDto<int>
    {
        public int? ProductId { get; set; }
    }
}
