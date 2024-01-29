using Abp.Application.Services.Dto;
using Souccar.Hcpc.Plans.Dto.PlanMaterials;
using Souccar.Hcpc.Plans.Dto.PlanProducts;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto;
using System.Collections.Generic;
using System;
using Souccar.Core.CustomAttributes;
using System.Linq;

namespace Souccar.Hcpc.Plans.Dto.Plans
{
    public class ReadPlanDto : EntityDto<int>
    {
        public ReadPlanDto()
        {
            PlanProducts = new List<PlanProductDto>();
            PlanMaterials = new List<PlanMaterialDto>();
            OutputRequests = new List<OutputRequestDto>();
        }
        [ReadUserInterface(Searchable = true)]
        public string Title { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }

        [ReadUserInterface(Searchable = true)]
        public int Status { get; set; }

        public int TotalItems => PlanProducts.Sum(x => x.NumberOfItems);

        /// <summary>
        /// المبلغ المهدور في كامل الخطة
        /// </summary>
        public float PlanAmountWasted => (float)PlanProducts.Sum(x => x.AmountWasted);

        /// <summary>
        /// موازنة الخطة / قيمة الربح او الخسارة
        /// </summary>
        public float PlanArbitrage => (float)PlanProducts.Sum(x => x.ProductArbitrage);

        /// <summary>
        /// إمكانية تنفيذ الخطة
        /// </summary>
        public bool Lack => PlanProducts.Any(x => x.CanProduce < x.NumberOfItems) ? false : true;

        public IList<PlanProductDto> PlanProducts { get; set; }
        public IList<PlanMaterialDto> PlanMaterials { get; set; }
        public IList<OutputRequestDto> OutputRequests { get; set; }

    }
}
