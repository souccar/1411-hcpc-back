using Abp.Application.Services.Dto;
using Souccar.Hcpc.Plans.Dto.Plans;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestMaterialDtos;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Dto
{
    public class OutputRequestDto : IEntityDto<int>
    {
        public OutputRequestDto()
        {
            OutputRequestMaterials = new List<OutputRequestMaterialDto>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string OutputDate { get; set; }
        public int? PlanId { get; set; }

        public PlanNameDto Plan { get; set; }

        public List<OutputRequestMaterialDto> OutputRequestMaterials { get; set; }

    }
}
