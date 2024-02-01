using Abp.Application.Services.Dto;
using Souccar.Hcpc.Materials.Dto.MaterialSuppliersDtos;
using Souccar.Hcpc.Suppliers.Dto;
using System.Collections.Generic;

namespace Souccar.Hcpc.Materials.Dto
{
    public class MaterialDto: MaterialBaseDto, IEntityDto<int>
    {
        public MaterialDto()
        {
            Suppliers = new List<MaterialSuppliersDto>();
        }
        public int Id { get; set; }

   
        public IList<MaterialSuppliersDto> Suppliers { get; set; }
    }
}
