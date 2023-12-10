using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Souccar.Hcpc.Plans;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.Hcpc.Warehouses
{
    public class OutputRequest : FullAuditedAggregateRoot, IMayHaveTenant
    {
        public OutputRequest()
        {
            OutputRequestMaterials = new List<OutputRequestMaterial>();
            OutputRequestProducts = new List<OutputRequestProduct>();
        }
        public int? TenantId { get; set; }
        public string Title { get; set; }
        public DateTime? OutputDate { get; set; }
       public OutputRequestStatus Status { get; set; }

        #region Plan
        public int? PlanId { get; set; }

        [ForeignKey("PlanId")]
        public virtual Plan Plan { get; set; }
        #endregion

        
        public virtual IList<OutputRequestProduct> OutputRequestProducts { get; set; }
        public virtual IList<OutputRequestMaterial> OutputRequestMaterials { get; set; }
    }
}