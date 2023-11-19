namespace Souccar.Hcpc.Plans.Dto.PlanMaterials
{
    public class CreatePlanMaterialDto
    {
        public double TotalQuantity { get; set; }
        public double InventoryQuantity { get; set; }
        public int? UnitId { get; set; }
        public int? MaterialId { get; set; }
        public int PlanId { get; set; }
    }
}
