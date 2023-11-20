using Souccar.Hcpc.Materials.Dto.MaterialSuppliersDtos;
using System.Collections.Generic;

namespace Souccar.Hcpc.Materials.Dto
{
    public class CreateMaterialDto: MaterialBaseDto
    {
        public CreateMaterialDto()
        {
            Suppliers = new List<CreateMaterialSuppliersDto>();
        }
        public IList<CreateMaterialSuppliersDto> Suppliers { get; set; }
    }
}
