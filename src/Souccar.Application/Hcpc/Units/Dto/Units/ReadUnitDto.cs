using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Units.Dto.Units
{
    public class ReadUnitDto : UnitDto, IEntityDto<int>
    {
        public int Id { get; set; }
    }
}
