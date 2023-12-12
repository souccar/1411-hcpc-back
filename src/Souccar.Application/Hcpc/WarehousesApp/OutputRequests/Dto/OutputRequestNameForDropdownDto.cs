using Abp.Application.Services.Dto;
using Souccar.Hcpc.Plans.Dto.Plans;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Dto
{
    public class OutputRequestNameForDropdownDto: EntityDto<int>
    {
        public string Title { get; set; }
        
    }
}
