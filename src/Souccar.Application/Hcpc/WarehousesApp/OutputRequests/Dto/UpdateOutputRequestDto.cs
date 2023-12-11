using Abp.Application.Services.Dto;
using Souccar.Hcpc.Products.Dto.Products.OutputRequestProductDtos;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestMaterialDtos;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Dto
{
    public class UpdateOutputRequestDto : IEntityDto<int>
    {
       
        public UpdateOutputRequestDto()
        {
            OutputRequestMaterials = new List<UpdateOutputRequestMaterialDto>();
            Products = new List<OutputRequestProductDto>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? PlanId { get; set; }

        public List<UpdateOutputRequestMaterialDto> OutputRequestMaterials { get; set; }
        public List<OutputRequestProductDto> Products { get; set; }

    }
}
