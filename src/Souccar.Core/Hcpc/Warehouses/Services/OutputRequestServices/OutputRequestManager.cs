using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.Hcpc.Warehouses.Services.OutputRequestServices
{
    public class OutputRequestManager : SouccarDomainService<OutputRequest, int>, IOutputRequestManager
    {
        public OutputRequestManager(IRepository<OutputRequest> repository) : base(repository)
        {

        }
    }
}
