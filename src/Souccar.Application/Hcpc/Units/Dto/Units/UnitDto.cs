using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Units.Dto.Units
{
    public class UnitDto : UnitBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }

    }
}
