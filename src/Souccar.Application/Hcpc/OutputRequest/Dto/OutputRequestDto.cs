using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.OutputRequests.Dto
{
    public class OutputRequestDto : OutputRequestBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }

    }
}
