using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.OutputRequest.Dto.OutputRequestMaterialDtos
{
    public class ReadOutputRequestMaterialDto : IEntityDto<int>
    {
        public double Quantity { get; set; }
        public int? UnitId { get; set; }
        public int? MaterialId { get; set; }
        public int Id { get; set; }
    }
}
