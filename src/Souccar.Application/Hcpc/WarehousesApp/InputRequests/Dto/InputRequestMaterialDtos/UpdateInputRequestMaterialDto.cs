using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.WarehousesApp.InputRequests.Dto.InputRequestMaterialDtos
{
    public class UpdateInputRequestMaterialDto : IEntityDto<int>
    {
        public int Id { get; set; }
        public double Quantity { get; set; }
        public string ExpirationDate { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }


        public int? UnitId { get; set; }
        public int? MaterialId { get; set; }
        public int? SupplierId { get; set; }
        public int? WarehouseId { get; set; }
    }
}
