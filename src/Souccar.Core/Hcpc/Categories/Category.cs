using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using Souccar.Hcpc.Products;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.Hcpc.Categories
{
    public class Category : Entity<int>, IMayHaveTenant
    {

        public Category()
        {
            Products = new List<Product>();
        }
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        #region Parent Category
        public int? ParentCategoryId { get; set; }

        [ForeignKey("ParentCategoryId")]
        public virtual Category ParentCategory { get; set; }
        #endregion

        #region Products
        public virtual IList<Product> Products { get; set; }
        #endregion
    }
}
