using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.InputRequests.Dto
{
    public class UpdateInputRequestDto : InputRequestBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
    }
}
