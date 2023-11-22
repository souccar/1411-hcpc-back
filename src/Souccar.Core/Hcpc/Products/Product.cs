using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace Souccar.Hcpc.Products
{
    public class Product : FullAuditedAggregateRoot, IMayHaveTenant
    {
        public Product()
        {
            Formulas = new List<Formula>();
        }
        public int? TenantId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int ExpectedProduce { get; set; }

        public virtual IList<Formula> Formulas { get; set; }
    }
}
