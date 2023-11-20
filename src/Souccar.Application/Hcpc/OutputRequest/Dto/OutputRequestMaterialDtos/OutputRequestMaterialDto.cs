using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.OutputRequest.Dto.OutputRequestMaterialDtos
{
    public class OutputRequestMaterialDto : IEntityDto<int>
    {
        public int Id { get; set; }
        public double Quantity { get; set; }
        public int? UnitId { get; set; }
        public int? MaterialId { get; set; }
    }
}
