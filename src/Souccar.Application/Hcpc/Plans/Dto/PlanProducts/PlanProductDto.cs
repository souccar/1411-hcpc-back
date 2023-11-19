using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Souccar.Hcpc.Plans.Dto.PlanProductMaterials;
using Souccar.Hcpc.Products;
using Souccar.Hcpc.Products.Dto.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Plans.Dto.PlanProducts
{
    public class PlanProductDto: EntityDto<int>
    {
        public PlanProductDto()
        {
            PlanProductMaterials = new List<PlanProductMaterialDto>();
        }
        public int NumberOfItems { get; set; }
        public PriorityInPlan Priority { get; set; }
        public int ProductId { get; set; }
        public int PlanId { get; set; }
        public ProductDto Product { get; set; }
        public IList<PlanProductMaterialDto> PlanProductMaterials { get; set; }
    }
}
