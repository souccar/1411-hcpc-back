using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System.Collections.Generic;
using System;
using Souccar.Hcpc.DailyProductions;
using Souccar.Hcpc.Warehouses;

namespace Souccar.Hcpc.Plans
{
    public class Plan : FullAuditedAggregateRoot<int>, IMayHaveTenant
    {
        public Plan()
        {
            PlanProducts = new List<PlanProduct>();
            OutputRequests = new List<OutputRequest>();

            //PlanMaterials = new List<PlanMaterial>();
            //DailyProduction = new List<DailyProduction>();
        }
        public int? TenantId { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public PlanStatus Status { get; set; }
        public int TotalItems { get; set; }
        public DateTime? StartDate { get; set; }
        public virtual IList<PlanProduct> PlanProducts { get; set; }
        public virtual IList<OutputRequest> OutputRequests { get; set; }

        //public virtual IList<PlanMaterial> PlanMaterials { get; set; }
        //public virtual IList<DailyProduction> DailyProduction { get; set; }
    }
}
