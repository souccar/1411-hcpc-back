using Souccar.Hcpc.Products.Dto.Products.OutputRequestProductDtos;
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
            Products = new List<CreateOutputRequestProductDto>();
        }

        public string Title { get; set; }
        public int? PlanId { get; set; }

        public List<CreateOutputRequestMaterialDto> OutputRequestMaterials { get; set; }
        public List<CreateOutputRequestProductDto> Products { get; set; }
    }
}
