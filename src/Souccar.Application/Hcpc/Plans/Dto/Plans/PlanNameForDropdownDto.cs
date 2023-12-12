using Abp.Application.Services.Dto;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto;
using System.Collections.Generic;

namespace Souccar.Hcpc.Plans.Dto.Plans
{
    public class PlanNameForDropdownDto : EntityDto<int>
    {
        public PlanNameForDropdownDto()
        {
            OutputRequests = new List<OutputRequestNameForDropdownDto>();
        }
        public string Title { get; set; }
        public IList<OutputRequestNameForDropdownDto> OutputRequests { get; set; }
    }
}
