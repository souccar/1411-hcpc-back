using Souccar.Hcpc.WarehousesApp.Dto.OutputRequests.OutputRequestProductDtos;
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
            OutputRequestProducts = new List<CreateOutputRequestProductDto>();
        }

        public string Title { get; set; }
        public int? PlanId { get; set; }

        public List<CreateOutputRequestMaterialDto> OutputRequestMaterials { get; set; }
        public List<CreateOutputRequestProductDto> OutputRequestProducts { get; set; }
    }
}
