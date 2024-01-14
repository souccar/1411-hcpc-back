using Abp.Application.Services.Dto;
using Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto;
using System.Collections.Generic;

namespace Souccar.Hcpc.Materials.Dto
{
    public class MaterialincludeWarehouseMaterialDto: EntityDto
    {
        public MaterialincludeWarehouseMaterialDto()
        {
            WarehouseMaterials = new List<WarehouseMaterialIdDto>();
        }
        public IList<WarehouseMaterialIdDto> WarehouseMaterials { get; set; }
    }
}
