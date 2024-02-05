using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.Workflows.Services.Interfaces;
using System.Linq;

namespace Souccar.Workflows.Services.Implements
{
    public class WorkflowStepManager : SouccarDomainService<WorkflowStep, int>, IWorkflowStepManager
    {
        private readonly IRepository<WorkflowStep, int> _workflowStepRepository;

        public WorkflowStepManager(IRepository<WorkflowStep, int> workflowStepRepository) : base(workflowStepRepository)
        {
            _workflowStepRepository = workflowStepRepository;
        }

        public WorkflowStep GetWithDetails(int id)
        {
            var workflowStep = _workflowStepRepository.GetAllIncluding(x => x.Actions).Include(y => y.Groups)
                .FirstOrDefault(z=>z.Id == id);
            return workflowStep;
        }
    }
}
