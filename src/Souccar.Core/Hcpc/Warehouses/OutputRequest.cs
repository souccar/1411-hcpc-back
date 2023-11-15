using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace Souccar.Hcpc.Warehouses
{
    public class OutputRequest : FullAuditedAggregateRoot, IMayHaveTenant
    {
        public OutputRequest()
        {
            OutputRequestMaterials = new List<OutputRequestMaterial>();
        }
        public int? TenantId { get; set; }
        public string Title { get; set; }
        public virtual IList<OutputRequestMaterial> OutputRequestMaterials { get; set; }
    }
}