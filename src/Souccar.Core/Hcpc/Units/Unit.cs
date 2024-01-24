using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.Hcpc.Units
{
    public class Unit : FullAuditedAggregateRoot, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public string Name { get; set; }

        #region Parent Unit
        public int? ParentUnitId { get; set; }

        [ForeignKey("ParentUnitId")]
        public virtual Unit ParentUnit { get; set; }
        #endregion
    }
}
