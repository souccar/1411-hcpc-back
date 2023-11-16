using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Materials.Dto
{
    public class MaterialNameForDropdownDto : EntityDto<int>
    {
        public MaterialNameForDropdownDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }
    }
}
