using Abp.Application.Services.Dto;
using Souccar.Users.Dto;

namespace Souccar.Hcpc.WarehousesApp.Warehouses.Dto
{
    public class ReadWarehouseDto : IEntityDto
    {
        public ReadWarehouseDto()
        {
            //WarehouseMaterials = new List<ReadWarehouseMaterialDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public long? WarehouseKeeperId { get; set; }
        public UserForDropdownDto WarehouseKeeper { get; set; }
        //public IList<ReadWarehouseMaterialDto> WarehouseMaterials { get; set; }
    }
}
