namespace Souccar.Workflows.Dto.WorkflowDtos
{
    public class CreateWorkflowDto
    {
        public CreateWorkflowDto()
        {
            //Steps = new List<CreateWorkflowStepDto>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        //public IList<CreateWorkflowStepDto> Steps { get; set; }
    }
}
