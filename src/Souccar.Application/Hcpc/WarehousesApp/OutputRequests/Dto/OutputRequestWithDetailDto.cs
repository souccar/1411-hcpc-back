using Abp.Application.Services.Dto;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionDtos;
using Souccar.Hcpc.Plans.Dto.Plans;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestMaterialDtos;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestProducts;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Dto
{
    public class OutputRequestWithDetailDto: EntityDto<int>
    {
        public OutputRequestWithDetailDto()
        {
            OutputRequestMaterials = new List<OutputRequestMaterialDto>();
        }

        public string Title { get; set; }
        public string OutputDate { get; set; }
        public int? PlanId { get; set; }
        public OutputRequestStatus Status { get; set; }
        public PlanNameDto Plan { get; set; }
        public List<OutputRequestMaterialDto> OutputRequestMaterials { get; set; }
        public List<OutputRequestProductDto> OutputRequestProducts { get; set; }
        public List<DailyProductionDto> DailyProductions { get; set; }
    }
}
