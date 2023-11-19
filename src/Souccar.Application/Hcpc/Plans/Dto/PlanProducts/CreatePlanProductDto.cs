using Abp.Application.Services.Dto;
using Souccar.Hcpc.Plans.Dto.PlanProductMaterials;
using Souccar.Hcpc.Products.Dto.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Plans.Dto.PlanProducts
{
    public class CreatePlanProductDto
    {
        public int NumberOfItems { get; set; }
        public PriorityInPlan Priority { get; set; }
        public int ProductId { get; set; }
        public int PlanId { get; set; }
    }
}
