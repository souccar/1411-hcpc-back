using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.InputRequests.Dto
{
    public class ReadInputRequestDto : InputRequestDto, IEntityDto<int>
    {
        public int Id { get; set; }
        
    }
}
