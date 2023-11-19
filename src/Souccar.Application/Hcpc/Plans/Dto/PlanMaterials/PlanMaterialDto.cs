using Abp.Application.Services.Dto;
using Souccar.Hcpc.Materials;
using Souccar.Hcpc.Units;

namespace Souccar.Hcpc.Plans.Dto.PlanMaterials
{
    public class PlanMaterialDto: EntityDto<int>
    {
        public double TotalQuantity { get; set; }
        public double InventoryQuantity { get; set; }
        public int? UnitId { get; set; }
        public int? MaterialId { get; set; }
        public int PlanId { get; set; }
        public Unit Unit { get; set; }
        public Material Material { get; set; }
    }
}
