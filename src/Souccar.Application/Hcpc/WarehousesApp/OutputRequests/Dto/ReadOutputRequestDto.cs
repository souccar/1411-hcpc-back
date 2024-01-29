using Abp.Application.Services.Dto;
using Souccar.Core.CustomAttributes;
using Souccar.Hcpc.Plans.Dto.Plans;
using Souccar.Hcpc.Products.Dto.Products;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestMaterialDtos;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestProductDtos;
using System;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Dto
{
    public class ReadOutputRequestDto : EntityDto<int>
    {
        public ReadOutputRequestDto()
        {
            OutputRequestMaterials = new List<ReadOutputRequestMaterialDto>();
            OutputRequestProducts = new List<ReadOutputRequesProductDto>();
        }
        [ReadUserInterface(Searchable = true)]
        public string Title { get; set; }

        public DateTime OutputDate { get; set; }

        [ReadUserInterface(Searchable = true)]
        public OutputRequestStatus Status { get; set; }
        public int? PlanId { get; set; }
        public PlanDto Plan { get; set; }

        public List<ReadOutputRequestMaterialDto> OutputRequestMaterials { get; set; }
        public List<ReadOutputRequesProductDto> OutputRequestProducts { get; set; }

    }
}
