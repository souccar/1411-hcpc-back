using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Plans.Dto.Plans
{
    public class PlanNameForDropdownDto : EntityDto<int>
    {
        public PlanNameForDropdownDto(int id, string title)
        {
            Id = id;
            Title = title;
        }
        public string Title { get; set; }
    }
}
