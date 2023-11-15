using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.WarehouseMaterials.Dto
{
    public class UpdateWarehouseMaterialDto: WarehouseMaterialBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
    }
}
