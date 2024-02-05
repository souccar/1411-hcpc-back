using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Workflows.Dto.WorkflowStepDtos;

namespace Souccar.Workflows.Services.Interfaces
{
    public interface IWorkflowStepAppService : IAsyncSouccarAppService<WorkflowStepDto, int, FullPagedRequestDto, CreateWorkflowStepDto, UpdateWorkflowStepDto>
    {
    }
}
