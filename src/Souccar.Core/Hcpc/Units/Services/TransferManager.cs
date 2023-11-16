using Abp.Domain.Repositories;
using Abp.UI;
using Souccar.Core.Services.Implements;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Units.Services
{
    public class TransferManager : SouccarDomainService<Transfer, int>, ITransferManager
    {
        private readonly IRepository<Transfer, int> _transferRepository;
        public TransferManager(IRepository<Transfer, int> transferRepository) : base(transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public async Task<double> ConvertTo(int fromId, int toId, double value)
        {
            Transfer transfer;
            transfer = await _transferRepository.FirstOrDefaultAsync(x => x.From.Id == fromId && x.To.Id == toId);
            if(transfer != null)
            {
                return value * transfer.Value;
            }

            transfer = await _transferRepository.FirstOrDefaultAsync(x => x.To.Id == fromId && x.From.Id == toId);
            if (transfer != null)
            {
                return value / transfer.Value;
            }

            throw new UserFriendlyException("TransferNotExist");
            
        }
    }
}
