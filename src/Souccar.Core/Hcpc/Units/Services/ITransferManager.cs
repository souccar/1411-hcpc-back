using Abp.Domain.Services;
using Souccar.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Units.Services
{
    public interface ITransferManager: ISouccarDomainService<Transfer, int>
    {
        Task<double> ConvertTo(int? fromId, int? toId, double value);
    }
}
