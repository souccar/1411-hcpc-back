using Abp.Application.Services.Dto;
using Souccar.Hcpc.Materials.Dto.MaterialSuppliersDtos;
using System.Collections.Generic;

namespace Souccar.Hcpc.Materials.Dto
{
    public class UpdateMaterialDto: EntityDto<int>
    {
        public UpdateMaterialDto()
        {
            Suppliers = new List<UpdateMaterialSuppliersDto>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LeadTime { get; set; }
        public double Price { get; set; }
        public IList<UpdateMaterialSuppliersDto> Suppliers { get; set; }
    }
}
