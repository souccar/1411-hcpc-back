using Souccar.Hcpc.Suppliers;
using Souccar.Hcpc.Suppliers.Dto;

namespace Souccar.Hcpc.Materials.Dto.MaterialSuppliersDtos
{
    public class ReadMaterialSuppliersDto
    {
        public int Id { get; set; }
        public ReadSupplierDto Supplier { get; set; }
        public int LeadTime { get; set; }
    }
}
