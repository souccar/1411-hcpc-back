using Abp.Domain.Services;
using Souccar.Core.Services;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Units.Services
{
    public interface ITransferManager: ISouccarDomainService<Transfer, int>
    {
        Task<double> ConvertTo(Unit source, Unit destination, double value);
    }
}
