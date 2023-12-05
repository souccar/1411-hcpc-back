using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Dto
{
    public class OutputRequestTitleDto : IEntityDto<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
