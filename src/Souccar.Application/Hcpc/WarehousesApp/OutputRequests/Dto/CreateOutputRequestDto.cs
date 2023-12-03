using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestMaterialDtos;
using System;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Dto
{
    public class CreateOutputRequestDto
    {
        public CreateOutputRequestDto()
        {
            OutputRequestMaterials = new List<CreateOutputRequestMaterialDto>();
        }

        public string Title { get; set; }
        public string OutputDate { get; set; }
        public int? PlanId { get; set; }

        public List<CreateOutputRequestMaterialDto> OutputRequestMaterials { get; set; }
    }
}
