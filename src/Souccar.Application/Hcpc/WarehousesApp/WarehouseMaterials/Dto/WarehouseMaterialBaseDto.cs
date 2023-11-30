namespace Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto
{
    public class WarehouseMaterialBaseDto
    {
        public int? TenantId { get; set; }
        public double Quantity { get; set; }
        public int UnitId { get; set; }
        public int MaterialId { get; set; }
    }
}
