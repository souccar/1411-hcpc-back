using Souccar.Core.Services;
using Souccar.Hcpc.Units;
using Souccar.Hcpc.Units.Dto.Transfers;
using Souccar.Hcpc.Units.Services;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Transfers.Services.Transfers
{
    public class TransferAppService :
        AsyncSouccarAppService<Transfer, TransferDto, int, PagedTransferRequestDto, CreateTransferDto, UpdateTransferDto>, ITransferAppService
    {
        private readonly ITransferManager _transferDomainService;
        public TransferAppService(ITransferManager transferDomainService) : base(transferDomainService)
        {
            _transferDomainService = transferDomainService;
        }

        public async Task<ConvertToOutputDto> ConvertTo(ConvertToInputDto input)
        {
            var value = await _transferDomainService.ConvertTo(input.FromId, input.ToId, input.Value);
            return new ConvertToOutputDto(value);
        }
    }
}
