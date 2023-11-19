using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Souccar.Hcpc.Plans
{
    public class Plan : FullAuditedAggregateRoot<int>, IMayHaveTenant
    {
        public Plan()
        {
            PlanProducts = new List<PlanProduct>();
        }
        public int? TenantId { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        
        public DateTime? StartDate { get; set; }
        public virtual IList<PlanProduct> PlanProducts { get; set; }

        #region Getters
        public int TotalItems => PlanProducts.Sum(x => x.NumberOfItems);
        #endregion
    }
}
