using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.Hcpc.Warehouses.Services
{
    public class InputRequestManager : SouccarDomainService<InputRequest, int>, IInputRequestManager
    {
        public InputRequestManager(IRepository<InputRequest> repository) : base(repository)
        {

        }
    }
}
