using Souccar.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Warehouses.Services.OutputRequestServices
{
    public interface IOutputRequestManager : ISouccarDomainService<OutputRequest, int>
    {
        OutputRequest GetOutputRequestWithDetails(int id);
    }
}
