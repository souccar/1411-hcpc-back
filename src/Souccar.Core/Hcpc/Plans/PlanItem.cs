using Abp.Domain.Entities;
using Souccar.Hcpc.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.Hcpc.Plans
{
    public class PlanItem : Entity<int>, IMayHaveTenant
    {
        //public PlanItem(double quantityInFormula, double quantityInPlan, double quantityInWarehoure, int? formulaId)
        //{
        //    QuantityInFormula = quantityInFormula;
        //    QuantityInPlan = quantityInPlan;
        //    QuantityInWarehoure = quantityInWarehoure;
        //    FormulaId = formulaId;
        //}

        public int? TenantId { get; set; }
        /// <summary>
        /// الكمية في الخلطة
        /// </summary>
        public double QuantityInFormula { get; set; }

        /// <summary>
        /// اجمالي كمية المادة في الخطة
        /// تساوي كمية المنتج في الخطة * الكمية في الخلطة
        /// = Plan.Count * QuantityInFormula
        /// </summary>
        public double QuantityInPlan { get; set; }

        /// <summary>
        /// كمية المادة في المستودع
        /// </summary>
        public double QuantityInWarehoure { get; set; }

        public int MaterialLeadTime { get; set; }
        public double MaterialPrice { get; set; }

        #region Formula
        public int? FormulaId { get; set; }

        [ForeignKey("FormulaId")]
        public Formula Formula { get; set; }
        #endregion

        

    }
}
