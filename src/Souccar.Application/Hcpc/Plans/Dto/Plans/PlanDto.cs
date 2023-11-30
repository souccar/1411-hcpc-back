using Abp.Application.Services.Dto;
using Souccar.Hcpc.Plans.Dto.PlanMaterials;
using Souccar.Hcpc.Plans.Dto.PlanProducts;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Souccar.Hcpc.Plans.Dto.Plans
{
    public class PlanDto : EntityDto<int>
    {
        public PlanDto()
        {
            PlanProducts = new List<PlanProductDto>();
            PlanMaterials = new List<PlanMaterialDto>();
            OutputRequests = new List<OutputRequestDto>();
        }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string StartDate { get; set; }
        
        public IList<PlanProductDto> PlanProducts { get; set; }
        public IList<PlanMaterialDto> PlanMaterials { get; set; }
        public IList<OutputRequestDto> OutputRequests { get; set; }

        public int TotalItems => PlanProducts.Sum(x => x.NumberOfItems);
        public bool Lack => PlanProducts.Any(x => x.CanProduce < x.NumberOfItems) ? false : true;
    }
}
