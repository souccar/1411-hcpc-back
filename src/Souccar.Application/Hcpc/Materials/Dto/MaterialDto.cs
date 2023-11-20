using Abp.Application.Services.Dto;
using Souccar.Hcpc.Suppliers.Dto;
using System.Collections.Generic;

namespace Souccar.Hcpc.Materials.Dto
{
    public class MaterialDto: MaterialBaseDto, IEntityDto<int>
    {
        public MaterialDto()
        {
            Suppliers = new List<SupplierDto>();
        }
        public int Id { get; set; }
        public IList<SupplierDto> Suppliers { get; set; }
    }
}
