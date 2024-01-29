using Abp.Application.Services.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Hcpc.Units.Dto.Transfers;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Transfers.Services.Transfers
{
    public interface ITransferAppService : IAsyncSouccarAppService<TransferDto, int, FullPagedRequestDto, CreateTransferDto, UpdateTransferDto>
    {
       public Task<ConvertToOutputDto> ConvertTo(ConvertToInputDto input);

        //public TransferToGreaterUnitOutputDto ConvertToGreaterUnit(TransferToGreaterUnitInputDto input);  

    }
}
