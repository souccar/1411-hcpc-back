using Abp.Application.Services.Dto;
using Souccar.Hcpc.Plans.Dto.Plans;
using Souccar.Hcpc.Products.Dto.Products;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestMaterialDtos;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestProductDtos;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Dto
{
    public class OutputRequestDto : IEntityDto<int>
    {
        public OutputRequestDto()
        {
            OutputRequestMaterials = new List<OutputRequestMaterialDto>();
            OutputRequestProducts = new List<ReadOutputRequesProductDto>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string OutputDate { get; set; }
        public OutputRequestStatus Status { get; set; }
        public int? PlanId { get; set; }
        public PlanNameDto Plan { get; set; }

        public List<OutputRequestMaterialDto> OutputRequestMaterials { get; set; }
        public List<ReadOutputRequesProductDto> OutputRequestProducts { get; set; }

    }
}
