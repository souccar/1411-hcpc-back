using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Events.Bus;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.Hcpc.Warehouses.Events;
using System;
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
            var outputRequest = _outputRequestRepository.GetAllIncluding(x => x.Plan)
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

        public IQueryable<OutputRequest> GetWithDetails(int planId)
        {
            var outputRequest = _outputRequestRepository.GetAllIncluding()
                .Include(dp => dp.DailyProductions).ThenInclude(dpd => dpd.DailyProductionDetails)
                .Include(om => om.OutputRequestMaterials).ThenInclude(wm => wm.WarehouseMaterial)
                .Include(op => op.OutputRequestProducts).ThenInclude(p => p.Product).ThenInclude(f => f.Formulas)
                .Where(x => x.PlanId == planId);

            return outputRequest.OrderByDescending(x=>x.Id);
                
        }
    }
}
