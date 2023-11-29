using Abp.Application.Services.Dto;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Units.Dto.Units;

namespace Souccar.Hcpc.Plans.Dto.PlanMaterials
{
    public class PlanMaterialDto: EntityDto<int>
    {
        public double TotalQuantity { get; set; }
        public double InventoryQuantity { get; set; }
        public int? UnitId { get; set; }
        public int? MaterialId { get; set; }
        public int? PlanId { get; set; }
        /// <summary>
        /// كم تسمح لي هذه المادة أن انتج
        /// </summary>
        public int ProduceDays { get; set; }
        public UnitDto Unit { get; set; }
        public MaterialDto Material { get; set; }
    }
}
