using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Plans.Dto.PlanProductMaterials
{
    public class CreatePlanProductMaterialDto
    {
        public double Quantity { get; set; }
        public int? UnitId { get; set; }
        public int? MaterialId { get; set; }
    }
}
