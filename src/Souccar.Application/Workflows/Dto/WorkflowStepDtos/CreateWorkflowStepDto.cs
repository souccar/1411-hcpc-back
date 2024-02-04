using Souccar.Workflows.Dto.WorkflowStepActionDtos;
using Souccar.Workflows.Dto.WorkflowStepGroupDtos;
using System.Collections.Generic;

namespace Souccar.Workflows.Dto.WorkflowStepDtos
{
    public class CreateWorkflowStepDto
    {
        public CreateWorkflowStepDto()
        {
            Groups = new List<CreateWorkflowStepGroupDto>();
            Actions = new List<CreateWorkflowStepActionDto>();
        }
        public string Title { get; set; }
        public int Status { get; set; }
        public int Index { get; set; }
        public int? WorkflowId { get; set; }
        public IList<CreateWorkflowStepGroupDto> Groups { get; set; }
        public IList<CreateWorkflowStepActionDto> Actions { get; set; }
    }
}
