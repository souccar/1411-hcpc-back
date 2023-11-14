using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System.Collections.Generic;

namespace Souccar.Hcpc.Warehouses
{
    public class InputRequest : FullAuditedAggregateRoot, IMayHaveTenant
    {
        public InputRequest()
        {
            InputRequestMaterials = new List<InputRequestMaterial>();
        }
        public int? TenantId { get; set; }
        public string Title { get; set; }
        public virtual IList<InputRequestMaterial> InputRequestMaterials { get; set; }
    }
}
