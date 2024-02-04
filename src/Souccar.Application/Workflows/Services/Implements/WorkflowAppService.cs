using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Workflows.Dto.WorkflowDtos;
using Souccar.Workflows.Services.Interfaces;

namespace Souccar.Workflows.Services.Implements
{
    public class WorkflowAppService :
        AsyncSouccarAppService<Workflow, WorkflowDto, int, FullPagedRequestDto, CreateWorkflowDto, UpdateWorkflowDto>, IWorkflowAppService
    {
        private readonly IWorkflowManager _WorkflowDomainService;

        public WorkflowAppService(IWorkflowManager workflowDomainService) : base(workflowDomainService)
        {
            _WorkflowDomainService = workflowDomainService;
        }
    }
}
