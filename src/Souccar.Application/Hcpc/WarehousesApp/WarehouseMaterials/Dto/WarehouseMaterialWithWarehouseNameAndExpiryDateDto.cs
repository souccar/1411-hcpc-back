using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto
{
    public class WarehouseMaterialWithWarehouseNameAndExpiryDateDto : EntityDto
    {
        public WarehouseMaterialWithWarehouseNameAndExpiryDateDto(int id, string info) : base(id)
        {
            Info = info;
        }

        public string Info { get; set; }
    }
}
