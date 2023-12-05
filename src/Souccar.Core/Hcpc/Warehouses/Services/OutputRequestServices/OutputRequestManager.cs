using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Events.Bus;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.Hcpc.Warehouses.Events;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Warehouses.Services.OutputRequestServices
{
    public class OutputRequestManager : SouccarDomainService<OutputRequest, int>, IOutputRequestManager
    {
        private readonly IRepository<OutputRequest> _outputRequestRepository;
        public OutputRequestManager(IRepository<OutputRequest> repository, IRepository<OutputRequest> outputRequestRepository) : base(repository)
        {
            _outputRequestRepository = outputRequestRepository;
        }

        public OutputRequest GetOutputRequestWithDetails(int id)
        {
            var outputRequest = _outputRequestRepository.GetAllIncluding(x => x.Plan)
                .Include(x => x.OutputRequestMaterials).ThenInclude(y => y.WarehouseMaterial)
                .FirstOrDefault(x=>x.Id== id);

            return outputRequest;
        }
    }
}
