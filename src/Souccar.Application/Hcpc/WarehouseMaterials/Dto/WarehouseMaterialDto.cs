using Abp.Application.Services.Dto;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Suppliers.Dto;

namespace Souccar.Hcpc.WarehouseMaterials.Dto
{
    public class WarehouseMaterialDto: WarehouseMaterialBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
        public UnitDto Unit { get; set; }
        public MaterialDto Material { get; set; }
    }
}
