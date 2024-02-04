using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;
using Souccar.Workflows.Services.Interfaces;

namespace Souccar.Workflows.Services.Implements
{
    public class WorkflowStepManager : SouccarDomainService<WorkflowStep, int>, IWorkflowStepManager
    {
        private readonly IRepository<WorkflowStep, int> _workflowStepRepository;

        public WorkflowStepManager(IRepository<WorkflowStep, int> workflowStepRepository) : base(workflowStepRepository)
        {
            _workflowStepRepository = workflowStepRepository;
        }
    }
}
