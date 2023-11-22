using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Souccar.Hcpc.Plans.Dto.PlanMaterials;
using Souccar.Hcpc.Plans.Dto.PlanProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Plans.Dto.Plans
{
    public class PlanDto : EntityDto<int>
    {
        public PlanDto()
        {
            PlanProducts = new List<PlanProductDto>();
            PlanMaterials = new List<PlanMaterialDto>();
        }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string StartDate { get; set; }
        public IList<PlanProductDto> PlanProducts { get; set; }
        public IList<PlanMaterialDto> PlanMaterials { get; set; }

        public int TotalItems => PlanProducts.Sum(x => x.NumberOfItems);
    }
}
