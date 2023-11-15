using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.InputRequests.Dto;

namespace Souccar.Hcpc.InputRequests.Services
{
    public interface IInputRequestAppService: IAsyncSouccarAppService<InputRequestDto,int,PagedInputRequestDto,CreateInputRequestDto,UpdateInputRequestDto, InputRequestDto, EntityDto<int>>
    {
    }
}
