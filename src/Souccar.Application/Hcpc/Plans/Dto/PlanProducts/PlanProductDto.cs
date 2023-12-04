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

        /// <summary>
        /// عدد العبوات المراد إنتاجها
        /// </summary>
        public int NumberOfItems { get; set; }
        public PriorityInPlan Priority { get; set; }
        public int? PlanId { get; set; }
        public int? ProductId { get; set; }
        public ProductDto Product { get; set; }

        /// <summary>
        /// عدد العبوات الممكن إنتاجها بناءا على الكميات الموجودة في المستودع
        /// </summary>
        public int CanProduce => PlanProductMaterials.Any() ? PlanProductMaterials.Min(x => x.CanProduce) : 0;

        /// <summary>
        /// عدد العبوات المنتجة
        /// </summary>
        public int TotalProduction { get; set; }

        /// <summary>
        /// تكلفة تصنيع كل الكمية المطلوبة
        /// </summary>
        public double TotalCost { get; set; } 

        /// <summary>
        /// تكلفة تصنيع جميع العبوات المنتجة فقط
        /// </summary>
        public double ProduceCost { get; set; }

        /// <summary>
        /// قيمة المبلغ المهدور من عملية الإنتاج
        /// </summary>
        public double AmountWasted => TotalCost - ProduceCost;

        /// <summary>
        /// مبلغ المبيع الإجمالي حسب عدد العبوات المنتجة
        /// </summary>
        public double TotalSalesAmount => Product.Price * TotalProduction;

        /// <summary>
        /// الموازنة الخاصة بالمنتج / قيمة الربح او الخسارة
        /// </summary>
        public double ProductArbitrage => TotalSalesAmount - TotalCost;
        public IList<PlanProductMaterialDto> PlanProductMaterials { get; set; }
        
    }
}
