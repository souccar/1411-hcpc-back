using Abp.Application.Services.Dto;
using Souccar.Hcpc.Units.Dto.Units;
using Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestMaterialDtos
{
    public class OutputRequestMaterialDto : IEntityDto<int>
    {
        public int Id { get; set; }
        public double Quantity { get; set; }
        public int? UnitId { get; set; }
        public int? WarehouseMaterialId { get; set; }

        public UnitDto Unit { get; set; }
        public WarehouseMaterialNameDto WarehouseMaterial { get; set; }

    }
}
