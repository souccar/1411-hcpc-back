using Abp.Application.Services.Dto;
using Souccar.Hcpc.Suppliers.Dto;

namespace Souccar.Hcpc.Materials.Dto.MaterialSuppliersDtos
{
    public class MaterialSuppliersDto :  IEntityDto<int>
    {
        public int Id { get; set; }
        public SupplierDto Supplier { get; set; }
        public int LeadTime { get; set; }
    }
}
