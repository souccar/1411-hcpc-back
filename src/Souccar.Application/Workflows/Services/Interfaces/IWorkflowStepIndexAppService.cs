using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Workflows.Dto.WorkflowStepIndexDtos;

namespace Souccar.Workflows.Services.Interfaces
{
    public interface IWorkflowStepIndexAppService : IAsyncSouccarAppService<WorkflowStepIndexDto, int, FullPagedRequestDto, CreateWorkflowStepIndexDto, UpdateWorkflowStepIndexDto>
    {
    }
}
