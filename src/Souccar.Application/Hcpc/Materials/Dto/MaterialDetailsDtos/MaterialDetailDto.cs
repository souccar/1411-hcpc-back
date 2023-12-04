using Abp.Application.Services.Dto;
using Souccar.Hcpc.Materials.Dto.MaterialSuppliersDtos;
using Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Souccar.Hcpc.Materials.Dto.MaterialDetailsDtos
{
    public class MaterialDetailDto: EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double TotalQuantity => WarehouseMaterials !=null? WarehouseMaterials.Sum(x => x.CurrentQuantity) :0;
        public IList<MaterialSuppliersDto> Suppliers { get; set; }
        public IList<WarehouseMaterialDto> WarehouseMaterials { get; set; }

        


    }
}
