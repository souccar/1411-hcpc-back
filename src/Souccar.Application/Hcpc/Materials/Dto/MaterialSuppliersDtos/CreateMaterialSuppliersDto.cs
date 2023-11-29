using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.Materials.Dto.MaterialSuppliersDtos
{
    public class CreateMaterialSuppliersDto
    {
        //[Required]
        public int SupplierId { get; set; }
        public int LeadTime { get; set; }
    }
}
