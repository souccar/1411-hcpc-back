using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.InputRequest.Dto.InputRequestMaterialDto
{
    public class ReadInputRequestMaterialDto : IEntityDto<int>
    {
        public double Quantity { get; set; }
        public int? UnitId { get; set; }
        public int? MaterialId { get; set; }
        public int Id { get; set; }
    }
}
