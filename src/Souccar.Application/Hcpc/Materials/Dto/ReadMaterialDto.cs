using Abp.Application.Services.Dto;
using Souccar.Core.CustomAttributes;
using Souccar.Hcpc.Materials.Dto.MaterialSuppliersDtos;
using System.Collections.Generic;

namespace Souccar.Hcpc.Materials.Dto
{
    public class ReadMaterialDto:  EntityDto<int>
    {
        public ReadMaterialDto()
        {
            Suppliers = new List<ReadMaterialSuppliersDto>();
        }
        [ReadUserInterface(Searchable = true)]
        public string Name { get; set; }
        [ReadUserInterface(Searchable = true)]
        public string Code { get; set; }
        public string Description { get; set; }
        public IList<ReadMaterialSuppliersDto> Suppliers { get; set; }

    }
}
