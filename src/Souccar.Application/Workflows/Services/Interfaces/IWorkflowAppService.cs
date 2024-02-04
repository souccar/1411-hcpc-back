using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Workflows.Dto.WorkflowDtos;

namespace Souccar.Workflows.Services.Interfaces
{
    public interface IWorkflowAppService : IAsyncSouccarAppService<WorkflowDto, int, FullPagedRequestDto, CreateWorkflowDto, UpdateWorkflowDto>
    {
    }
}
