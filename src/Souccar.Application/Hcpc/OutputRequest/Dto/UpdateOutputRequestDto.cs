using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.OutputRequests.Dto
{
    public class UpdateOutputRequestDto : OutputRequestBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
    }
}
