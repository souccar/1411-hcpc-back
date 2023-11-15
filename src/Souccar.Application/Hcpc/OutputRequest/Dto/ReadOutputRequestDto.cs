using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.OutputRequests.Dto
{
    public class ReadOutputRequestDto : OutputRequestDto, IEntityDto<int>
    {
        public int Id { get; set; }
        
    }
}
