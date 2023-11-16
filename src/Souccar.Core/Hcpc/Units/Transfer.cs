using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.Hcpc.Units
{
    public class Transfer : FullAuditedAggregateRoot, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        #region FromUnit
        public int? FromId { get; set; }

        [ForeignKey("FromId")]
        public Unit From { get; set; }
        #endregion

        #region ToUnit 
        public int? ToId { get; set; }

        [ForeignKey("ToId")]
        public Unit To { get; set; }
        #endregion

        public double Value { get; set; }

    }
}
