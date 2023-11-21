using Abp.Application.Services.Dto;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Units.Dto.Units;

namespace Souccar.Hcpc.Plans.Dto.PlanProductMaterials
{
    public class PlanProductMaterialDto:EntityDto<int>
    {
        public double RequiredQuantity { get; set; }
        public int? UnitId { get; set; }
        public int? MaterialId { get; set; }
        public UnitDto Unit { get; set; }
        public MaterialDto Material { get; set; }
    }
}
