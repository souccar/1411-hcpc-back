using Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Souccar.Hcpc.Materials.Dto.MaterialDetailsDtos
{
    public class MaterialDetailsDto
    {
        public MaterialDetailsDto()
        {
            WarehouseMaterials = new List<WarehouseMaterialDto>();
        }

        public MaterialDetailsDto(MaterialDto material, IList<WarehouseMaterialDto> warehouseMaterials)
        {

            Material = material;
            WarehouseMaterials = warehouseMaterials;
        }
        public MaterialDto Material { get; set; }

        public double TotalQuantity
        {
            get
            {
                return WarehouseMaterials.Sum(x => x.Quantity);
            }
        }

        public IList<WarehouseMaterialDto> WarehouseMaterials { get; set; }
    }
}
