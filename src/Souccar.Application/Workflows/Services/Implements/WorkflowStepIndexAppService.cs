using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Workflows.Dto.WorkflowStepIndexDtos;
using Souccar.Workflows.Services.Interfaces;

namespace Souccar.Workflows.Services.Implements
{
    public class WorkflowStepIndexAppService :
        AsyncSouccarAppService<WorkflowStepIndex, WorkflowStepIndexDto, int, FullPagedRequestDto, CreateWorkflowStepIndexDto, UpdateWorkflowStepIndexDto>, IWorkflowStepIndexAppService
    {
        private readonly IWorkflowStepIndexManager _WorkflowStepIndexDomainService;

        public WorkflowStepIndexAppService(IWorkflowStepIndexManager WorkflowStepIndexDomainService) : base(WorkflowStepIndexDomainService)
        {
            _WorkflowStepIndexDomainService = WorkflowStepIndexDomainService;
        }
    }
}
