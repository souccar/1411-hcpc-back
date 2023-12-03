using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.WarehousesApp.Warehouses.Dto
{
    public class WarehouseNameForDropdownDto : EntityDto<int>
    {
        public WarehouseNameForDropdownDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public string Name { get; set; }
    }
}
