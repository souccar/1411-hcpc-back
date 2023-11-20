using Abp.Application.Services.Dto;
using Souccar.Hcpc.Materials.Dto.MaterialSuppliersDtos;
using System.Collections.Generic;

namespace Souccar.Hcpc.Materials.Dto
{
    public class ReadMaterialDto: MaterialBaseDto, IEntityDto<int>
    {
        public ReadMaterialDto()
        {
            Suppliers = new List<ReadMaterialSuppliersDto>();
        }
        public int Id { get; set; }
        public IList<ReadMaterialSuppliersDto> Suppliers { get; set; }

    }
}
