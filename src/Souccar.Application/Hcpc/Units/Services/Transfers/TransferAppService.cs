using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.Units;
using Souccar.Hcpc.Units.Dto.Transfers;
using Souccar.Hcpc.Units.Services;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Transfers.Services.Transfers
{
    public class TransferAppService :
        AsyncSouccarAppService<Transfer, TransferDto, int, PagedTransferRequestDto, CreateTransferDto, UpdateTransferDto, TransferDto, EntityDto<int>>, ITransferAppService
    {
        private readonly ITransferManager _transferDomainService;
        public TransferAppService(ITransferManager transferDomainService) : base(transferDomainService)
        {
            _transferDomainService = transferDomainService;
        }

        public async Task<double> ConvertTo(CreateTransferDto createTransferDto)
        {
            var transfer = ObjectMapper.Map<Transfer>(createTransferDto);
           return await _transferDomainService.ConvertTo(transfer.From,transfer.To,transfer.Value);
        }
    }
}
