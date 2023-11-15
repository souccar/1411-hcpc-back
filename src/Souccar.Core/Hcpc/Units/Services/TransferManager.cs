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
        }

        public async Task<double> ConvertTo(Unit from, Unit to, double value)
        {
            Transfer transfer;
            transfer = await _transferRepository.FirstOrDefaultAsync(x => x.From.Id == from.Id && x.To.Id == to.Id);
            if(transfer != null)
            {
                return value * transfer.Value;
            }

            transfer = await _transferRepository.FirstOrDefaultAsync(x => x.To.Id == from.Id && x.From.Id == to.Id);
            if (transfer != null)
            {
                return value / transfer.Value;
            }

            throw new UserFriendlyException("TransferNotExist");
            
        }
    }
}
