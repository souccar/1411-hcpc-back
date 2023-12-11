using Abp.Application.Services.Dto;
using Souccar.Hcpc.Plans.Dto.Plans;
using Souccar.Hcpc.Products.Dto.Products;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestMaterialDtos;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestProductDtos;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Dto
{
    public class ReadOutputRequestDto : IEntityDto<int>
    {
        public ReadOutputRequestDto()
        {
            OutputRequestMaterials = new List<ReadOutputRequestMaterialDto>();
            OutputRequestProducts = new List<ReadOutputRequesProductDto>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string OutputDate { get; set; }
        public int? PlanId { get; set; }

        public PlanDto Plan { get; set; }

        public List<ReadOutputRequestMaterialDto> OutputRequestMaterials { get; set; }
        public List<ReadOutputRequesProductDto> OutputRequestProducts { get; set; }

    }
}
