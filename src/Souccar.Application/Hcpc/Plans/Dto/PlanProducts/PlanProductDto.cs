using Abp.Application.Services.Dto;
using Souccar.Hcpc.Plans.Dto.PlanProductMaterials;
using Souccar.Hcpc.Products.Dto.Products;
using System.Collections.Generic;
using System.Linq;

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
        public int DurationProduce { get; set; }
        public int CanProduce => PlanProductMaterials.Any() ? PlanProductMaterials.Min(x => x.CanProduce) : 0;
        public IList<PlanProductMaterialDto> PlanProductMaterials { get; set; }
        
    }
}
