using Souccar.Hcpc.Suppliers.Dto;
using System.Collections.Generic;

namespace Souccar.Hcpc.Materials.Dto
{
    public class CreateMaterialDto: MaterialBaseDto
    {
        public CreateMaterialDto()
        {
            Suppliers = new List<SupplierDto>();
        }
        public IList<SupplierDto> Suppliers { get; set; }
    }
}
