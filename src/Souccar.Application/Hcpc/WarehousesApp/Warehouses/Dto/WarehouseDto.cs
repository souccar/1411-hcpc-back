using Abp.Application.Services.Dto;
using Souccar.Users.Dto;

namespace Souccar.Hcpc.WarehousesApp.Warehouses.Dto
{
    public class WarehouseDto : EntityDto<int>
    {
        public WarehouseDto()
        {
            //WarehouseMaterials = new List<WarehouseMaterialDto>();
        }
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public long? WarehouseKeeperId { get; set; }
        public UserForDropdownDto WarehouseKeeper { get; set; }
        //public IList<WarehouseMaterialDto> WarehouseMaterials { get; set; }
    }
}
