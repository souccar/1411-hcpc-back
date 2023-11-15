using Abp.Application.Services.Dto;
using Souccar.Hcpc.Suppliers.Dto;

namespace Souccar.Hcpc.Materials.Dto
{
    public class ReadMaterialDto: MaterialBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
        public SupplierDto Supplier { get; set; }
        
    }
}
