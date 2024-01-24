using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Units.Dto.Units
{
    public class UnitNameForDropdownDto: EntityDto<int>
    {
        public string Name { get; set; }
    }
}
