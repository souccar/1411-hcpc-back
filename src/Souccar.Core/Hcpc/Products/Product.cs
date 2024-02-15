using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Souccar.Hcpc.Categories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.Hcpc.Products
{
    public class Product : FullAuditedAggregateRoot, IMayHaveTenant
    {
        public Product()
        {
            Formulas = new List<FormulaItem>();
        }
        public int? TenantId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Size { get; set; }
        public double Price { get; set; }

        public virtual IList<FormulaItem> Formulas { get; set; }

        #region Category

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public int? CategoryId { get; set; }
        #endregion
    }
}
