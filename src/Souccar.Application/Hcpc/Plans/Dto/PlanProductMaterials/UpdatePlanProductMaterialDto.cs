using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Plans.Dto.PlanProductMaterials
{
    public class UpdatePlanProductMaterialDto: EntityDto<int>
    {
        public double Quantity { get; set; }
        public int? UnitId { get; set; }
        public int? MaterialId { get; set; }
    }
}
