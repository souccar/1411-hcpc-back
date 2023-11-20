using Abp.Application.Services.Dto;
using Souccar.Hcpc.Materials.Dto.MaterialSuppliersDtos;
using System.Collections.Generic;

namespace Souccar.Hcpc.Materials.Dto
{
    public class UpdateMaterialDto: MaterialBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
        public UpdateMaterialDto()
        {
            Suppliers = new List<UpdateMaterialSuppliersDto>();
        }
        public IList<UpdateMaterialSuppliersDto> Suppliers { get; set; }
    }
}
