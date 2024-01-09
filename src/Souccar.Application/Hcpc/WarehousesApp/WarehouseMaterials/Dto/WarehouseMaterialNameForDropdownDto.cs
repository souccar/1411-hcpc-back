using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto
{
    public class WarehouseMaterialNameForDropdownDto : EntityDto<int>
    {
        public WarehouseMaterialNameForDropdownDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public string Name { get; set; }
    }
}
