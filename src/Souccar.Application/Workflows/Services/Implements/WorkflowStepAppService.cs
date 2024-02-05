﻿using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Workflows.Dto.WorkflowStepDtos;
using Souccar.Workflows.Services.Interfaces;
using System.Threading.Tasks;

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

        public async override Task<WorkflowStepDto> UpdateAsync(UpdateWorkflowStepDto input)
        {
            var workflowStep = _WorkflowStepDomainService.GetWithDetails(input.Id);

            ObjectMapper.Map<UpdateWorkflowStepDto, WorkflowStep>(input, workflowStep);

            var updatedWorkflowStep = await _WorkflowStepDomainService.UpdateAsync(workflowStep);

            return ObjectMapper.Map<WorkflowStepDto>(updatedWorkflowStep);
        }
    }
}
