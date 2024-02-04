using Abp.Application.Services.Dto;
using Souccar.Workflows.Dto.WorkflowStepActionDtos;
using Souccar.Workflows.Dto.WorkflowStepGroupDtos;
using System.Collections.Generic;

namespace Souccar.Workflows.Dto.WorkflowStepDtos
{
    public class UpdateWorkflowStepDto : EntityDto
    {
        public UpdateWorkflowStepDto()
        {
            Groups = new List<UpdateWorkflowStepGroupDto>();
            Actions = new List<UpdateWorkflowStepActionDto>();
        }
        public string Title { get; set; }
        public int Index { get; set; }
        public int? WorkflowId { get; set; }
        public IList<UpdateWorkflowStepGroupDto> Groups { get; set; }
        public IList<UpdateWorkflowStepActionDto> Actions { get; set; }
    }
}
