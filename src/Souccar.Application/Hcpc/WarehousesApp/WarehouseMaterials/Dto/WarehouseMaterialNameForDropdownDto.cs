using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto
{
    public class WarehouseMaterialNameForDropdownDto : EntityDto<int>
    {
        public WarehouseMaterialNameForDropdownDto(int id, string code)
        {
            Id = id;
            Code = code;
        }
        public string Code { get; set; }
    }
}
