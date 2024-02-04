using Abp.Application.Services.Dto;

namespace Souccar.Workflows.Dto.WorkflowStepActionDtos
{
    public class CreateWorkflowStepActionDto
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public int? WorkflowIndexId { get; set; }
    }
}
