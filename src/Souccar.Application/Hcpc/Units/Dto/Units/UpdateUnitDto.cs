using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Units.Dto.Units
{
    public class UpdateUnitDto : UnitDto, IEntityDto<int>
    {
        public int Id { get; set; }
    }
}
