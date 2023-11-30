namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestMaterialDtos
{
    public class CreateOutputRequestMaterialDto
    {
        public double Quantity { get; set; }
        public int? UnitId { get; set; }
        public int? WarehouseMaterialId { get; set; }
    }
}
