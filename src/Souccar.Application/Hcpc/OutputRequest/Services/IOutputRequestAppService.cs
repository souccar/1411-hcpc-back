using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.OutputRequests.Dto;

namespace Souccar.Hcpc.OutputRequests.Services
{
    public interface IOutputRequestAppService: IAsyncSouccarAppService<OutputRequestDto,int,PagedOutputRequestDto,CreateOutputRequestDto,UpdateOutputRequestDto, OutputRequestDto, EntityDto<int>>
    {
    }
}
