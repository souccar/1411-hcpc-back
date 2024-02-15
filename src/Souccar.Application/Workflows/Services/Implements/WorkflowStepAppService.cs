using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Workflows.Dto.WorkflowStepDtos;
using Souccar.Workflows.Services.Interfaces;

namespace Souccar.Workflows.Services.Implements
{
    public class WorkflowStepAppService :
        AsyncSouccarAppService<WorkflowStep, WorkflowStepDto, int, FullPagedRequestDto, CreateWorkflowStepDto, UpdateWorkflowStepDto>, IWorkflowStepAppService
    {
        private readonly IWorkflowStepManager _WorkflowStepDomainService;

        public WorkflowStepAppService(IWorkflowStepManager WorkflowStepDomainService) : base(WorkflowStepDomainService)
        {
            _WorkflowStepDomainService = WorkflowStepDomainService;
        }
    }
}
