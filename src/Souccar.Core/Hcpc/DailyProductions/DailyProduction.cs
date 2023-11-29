using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using Souccar.Hcpc.Plans;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Souccar.Hcpc.DailyProductions
{
    public class DailyProduction : FullAuditedAggregateRoot<int>, IMayHaveTenant
    {
        public DailyProduction()
        {
            DailyProductionDetails = new List<DailyProductionDetail>();
        }
        public int? TenantId { get; set; }

        #region Plan
        [ForeignKey("PlanId")]
        public virtual Plan Plan { get; set; }
        public int? PlanId { get; set; }
        #endregion

        #region Details
        public virtual IList<DailyProductionDetail> DailyProductionDetails { get; set; }
        #endregion
    }
}
