using System.Collections;
using System.Collections.Generic;

namespace Souccar.Hcpc.Materials.Dto
{
    public class MaterialsOfSupplierDto
    {
        public MaterialsOfSupplierDto()
        {
            MaterialNames = new List<MaterialOfSupplierInfoDto>();
        }
        public int SupplierId { get; set; }        
        public IList<MaterialOfSupplierInfoDto> MaterialNames { get; set; }
    }
}
