using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Plans.Dto.Plans
{
    public class PlanNameDto : EntityDto<int>
    {
        public string Title { get; set; }
    }
}
