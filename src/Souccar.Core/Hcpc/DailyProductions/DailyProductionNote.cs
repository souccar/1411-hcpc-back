using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.Hcpc.DailyProductions
{
    public class DailyProductionNote : FullAuditedEntity<int>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public string Note { get; set; }

        #region DailyProduction
        [ForeignKey("DailyProductionId")]
        public virtual DailyProduction DailyProduction { get; set; }
        public int? DailyProductionId { get; set; }
        #endregion
    }
}
