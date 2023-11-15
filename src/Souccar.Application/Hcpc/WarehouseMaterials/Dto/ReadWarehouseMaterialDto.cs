using Abp.Application.Services.Dto;
using Souccar.Hcpc.Suppliers.Dto;

namespace Souccar.Hcpc.WarehouseMaterials.Dto
{
    public class ReadWarehouseMaterialDto: WarehouseMaterialBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
        public SupplierDto Supplier { get; set; }
        
    }
}
