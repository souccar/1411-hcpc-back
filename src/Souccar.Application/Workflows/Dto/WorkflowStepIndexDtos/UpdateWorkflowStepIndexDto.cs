using Abp.Application.Services.Dto;

namespace Souccar.Workflows.Dto.WorkflowStepIndexDtos
{
    public class UpdateWorkflowStepIndexDto : EntityDto
    {
        public string ActionName { get; set; }
        public int Oreder { get; set; }
    }
}
