using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.Hcpc.Plans.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Warehouses.Services.OutputRequestServices
{
    public class OutputRequestManager : SouccarDomainService<OutputRequest, int>, IOutputRequestManager
    {
        private readonly IRepository<OutputRequest> _outputRequestRepository;
        private readonly IPlanManager _planManager;
        public OutputRequestManager(IRepository<OutputRequest> repository, IRepository<OutputRequest> outputRequestRepository, IPlanManager planManager) : base(repository)
        {
            _outputRequestRepository = outputRequestRepository;
            _planManager = planManager;
        }

        public OutputRequest GetOutputRequestWithDetails(int id)
        {
            var outputRequest = _outputRequestRepository.GetAllIncluding(x => x.Plan)
                .Include(x => x.OutputRequestProducts).ThenInclude(y => y.Product).ThenInclude(f => f.Formulas)
                .Include(x => x.OutputRequestMaterials).ThenInclude(y => y.WarehouseMaterial)
                .FirstOrDefault(x => x.Id == id);

            return outputRequest;
        }

        public async Task<OutputRequest> ChangeStatus(OutputRequestStatus status, int id)
        {
            var outputRequest = await _outputRequestRepository.GetAsync(id);
            if (outputRequest == null)
            {
                throw new UserFriendlyException("Output request not fount");
            }

            outputRequest.Status = status;

            if (status == OutputRequestStatus.InProduction)
            {
                outputRequest.OutputDate = DateTime.Now;
            }

            return await _outputRequestRepository.UpdateAsync(outputRequest);
        }

        public IQueryable<OutputRequest> GetWithDetails(int planId)
        {
            var outputRequest = _outputRequestRepository.GetAllIncluding()
                .Include(dp => dp.DailyProductions).ThenInclude(dpd => dpd.DailyProductionDetails)
                .Include(dp => dp.DailyProductions).ThenInclude(dpd => dpd.DailyProductionNotes)
                .Include(om => om.OutputRequestMaterials).ThenInclude(wm => wm.WarehouseMaterial)
                .Include(op => op.OutputRequestProducts).ThenInclude(p => p.Product).ThenInclude(f => f.Formulas)
                .Where(x => x.PlanId == planId);

            return outputRequest.OrderByDescending(x => x.Id);

        }

        public IQueryable<OutputRequest> GetPlanOutputRequests(int planId)
        {
            return _outputRequestRepository.GetAllIncluding().Include(x => x.OutputRequestProducts).ThenInclude(y => y.Product).Include(x => x.Plan);
        }

        public List<OutputRequest> GetAllIncluding()
        {
            var outputRequests = _outputRequestRepository.GetAllIncluding().Include(x => x.OutputRequestProducts).ThenInclude(p => p.Product).Include(p => p.Plan).ToList();
            return outputRequests;
        }

        public override Task DeleteAsync(int id)
        {
            var outputRequest = _outputRequestRepository.Get(id);
            if (outputRequest.Status == OutputRequestStatus.InProduction)
            {
                throw new UserFriendlyException("Cannot be deleted, Status is in production");
            }

            var relatedPlans = _planManager.GetAll().Any(x => x.Status == Plans.PlanStatus.Actual && x.OutputRequests.Any(y => y.Id == id));
            if (relatedPlans)
            {
                throw new UserFriendlyException("Cannot be deleted, This output request is associated with plans");
            }
            return base.DeleteAsync(id);
        }



        public IQueryable<OutputRequest> CreateFilteredQuery(string including, long? currentUserId)
        {
            IQueryable<OutputRequest> result;

            if (!string.IsNullOrEmpty(including))
            {
                var array = including.Split(',').ToList();
                var listProperties = typeof(OutputRequest).GetProperties()
                .Where(x =>
                    x.PropertyType.IsGenericType &&
                    x.PropertyType.GetGenericTypeDefinition() == typeof(IList<>));

                var referenceProperties = typeof(OutputRequest).GetProperties()
                .Where(x =>
                    x.PropertyType.IsClass && !x.PropertyType.IsAbstract);

                if (referenceProperties.Any() || listProperties.Any())
                {
                    var lambdaExp = new List<Expression<Func<OutputRequest, object>>>();
                    foreach (var prop in referenceProperties)
                    {
                        if (array.Any(x => x.Trim().ToLower() == prop.Name.ToLower()))
                        {
                            var paramName = prop.Name.Substring(0, 2).ToLower();
                            var parameter = Expression.Parameter(typeof(OutputRequest), paramName);
                            var member = Expression.Property(parameter, prop.Name);
                            var finalExpression = Expression.Lambda<Func<OutputRequest, object>>(member, parameter);
                            lambdaExp.Add(finalExpression);
                        }
                    }

                    foreach (var prop in listProperties)
                    {
                        if (prop.Name.ToLower() != "OutputRequestMaterials".ToLower())
                        {
                            if (array.Any(x => x.Trim().ToLower() == prop.Name.ToLower()))
                            {
                                var paramName = prop.Name.Substring(0, 2).ToLower();
                                var parameter = Expression.Parameter(typeof(OutputRequest), paramName);
                                var member = Expression.Property(parameter, prop.Name);
                                var finalExpression = Expression.Lambda<Func<OutputRequest, object>>(member, parameter);
                                lambdaExp.Add(finalExpression);
                            }
                        }
                    }
                    result = _outputRequestRepository.GetAllIncluding(lambdaExp.ToArray())
                        .Include(z => z.OutputRequestMaterials).ThenInclude(c => c.WarehouseMaterial).ThenInclude(q => q.Warehouse)
                        .Where(x => x.OutputRequestMaterials.Any(y => y.WarehouseMaterial.Warehouse.WarehouseKeeperId == currentUserId));
                    return result;
                }
            }
            result = _outputRequestRepository.GetAll()
                .Include(z => z.OutputRequestMaterials).ThenInclude(c => c.WarehouseMaterial).ThenInclude(q => q.Warehouse)
                        .Where(x => x.OutputRequestMaterials.Any(y => y.WarehouseMaterial.Warehouse.WarehouseKeeperId == currentUserId));
            return result;
        }
    }
}
