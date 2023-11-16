using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Units.Dto.Units
{
    public class UnitNameForDropdownDto: EntityDto<int>
    {
        public UnitNameForDropdownDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }
    }
}
