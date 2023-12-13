using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using Souccar.Hcpc.Plans;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Souccar.Hcpc.Warehouses;

namespace Souccar.Hcpc.DailyProductions
{
    public class DailyProduction : FullAuditedAggregateRoot<int>, IMayHaveTenant
    {
        public DailyProduction()
        {
            DailyProductionDetails = new List<DailyProductionDetail>();
            DailyProductionNotes = new List<DailyProductionNote>();
        }
        public int? TenantId { get; set; }

        #region Plan
        [ForeignKey("PlanId")]
        public virtual Plan Plan { get; set; }
        public int? PlanId { get; set; }
        #endregion

        #region Output request
        [ForeignKey("OutputRequestId")]
        public virtual OutputRequest OutputRequest { get; set; }
        public int? OutputRequestId { get; set; }
        #endregion

        public virtual IList<DailyProductionDetail> DailyProductionDetails { get; set; }
        public virtual IList<DailyProductionNote> DailyProductionNotes { get; set; }
    }
}
