using Abp.Application.Services.Dto;

namespace Souccar.Workflows.Dto.WorkflowDtos
{
    public class UpdateWorkflowDto : EntityDto
    {
        public UpdateWorkflowDto()
        {
            //Steps = new List<UpdateWorkflowStepDto>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        //public int Status { get; set; }
        //public IList<UpdateWorkflowStepDto> Steps { get; set; }
    }
}
