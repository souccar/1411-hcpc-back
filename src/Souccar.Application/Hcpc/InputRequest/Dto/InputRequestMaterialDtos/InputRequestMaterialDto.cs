using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.InputRequest.Dto.InputRequestMaterialDto
{
    public class InputRequestMaterialDto : IEntityDto<int>
    {
        public int Id { get; set; }
        public double Quantity { get; set; }
        public int? UnitId { get; set; }
        public int? MaterialId { get; set; }
    }
}
