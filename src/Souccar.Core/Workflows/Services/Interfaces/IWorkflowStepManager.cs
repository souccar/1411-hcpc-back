using Souccar.Core.Services.Interfaces;

namespace Souccar.Workflows.Services.Interfaces
{
    public interface IWorkflowStepManager : ISouccarDomainService<WorkflowStep, int>
    {
        WorkflowStep GetWithDetails(int id);
    }
}
