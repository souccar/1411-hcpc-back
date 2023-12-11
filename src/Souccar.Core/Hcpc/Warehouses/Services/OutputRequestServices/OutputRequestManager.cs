using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Events.Bus;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.Hcpc.Plans;
using Souccar.Hcpc.Warehouses.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            var outputRequest = _outputRequestRepository.GetAllIncluding(x => x.Plan).Include(x=>x.OutputRequestProducts).ThenInclude(y=>y.Product)
                .Include(x => x.OutputRequestMaterials).ThenInclude(y => y.WarehouseMaterial)
                .FirstOrDefault(x=>x.Id== id);

            return outputRequest;
        }

        public async Task<OutputRequest> ChangeStatus(OutputRequestStatus status, int id)
        {
            var outputRequest = await _outputRequestRepository.GetAsync(id);
            if(outputRequest == null)
            {
                throw new UserFriendlyException("Output request not fount");
            }

            outputRequest.Status = status;

            if(status == OutputRequestStatus.InProduction)
            {
                outputRequest.OutputDate = DateTime.Now;
            }

            return await _outputRequestRepository.UpdateAsync(outputRequest);
        }

        public IQueryable<OutputRequest> GetPlanOutputRequests(int planId)
        {
            return GetAllWithIncluding("Plan,OutputRequestProducts").Where(x=>x.PlanId== planId);
        }

        public List<OutputRequest> GetAllIncluding()
        {
            var putputRequests = _outputRequestRepository.GetAllIncluding().Include(x => x.OutputRequestProducts).ThenInclude(p => p.Product).ToList();
            return putputRequests;
        }

    }
}
