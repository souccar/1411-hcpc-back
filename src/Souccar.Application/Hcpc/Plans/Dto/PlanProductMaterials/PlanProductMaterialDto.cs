using Abp.Application.Services.Dto;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Units.Dto.Units;

namespace Souccar.Hcpc.Plans.Dto.PlanProductMaterials
{
    public class PlanProductMaterialDto:EntityDto<int>
    {

        /// <summary>
        /// الكمية المطلوبة من هذه المادة لإنتاج المنتج الحالي
        /// </summary>
        public double RequiredQuantity { get; set; }
        public int? UnitId { get; set; }
        public int? MaterialId { get; set; }
        public int? PlanProductId { get; set; }
        public int CanProduce { get; set; }
        public UnitDto Unit { get; set; }
        public MaterialDto Material { get; set; }
    }
}
