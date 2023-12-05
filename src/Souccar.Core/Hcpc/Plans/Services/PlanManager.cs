using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.Hcpc.Products.Services;
using Souccar.Hcpc.Warehouses.Services.WarehouseServices;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Plans.Services
{
    public class PlanManager : SouccarDomainService<Plan, int>, IPlanManager
    {
        private readonly IRepository<Plan> _planRepository;
        private readonly IFormulaManager _formulaManager;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IWarehouseMaterialManager _warehouseMaterialManager;

        public PlanManager(
            IRepository<Plan> planRepository,
            IFormulaManager formulaManager,
            IWarehouseMaterialManager warehouseMaterialManager,
            IUnitOfWorkManager unitOfWorkManager) : base(planRepository)
        {
            _planRepository = planRepository;
            _formulaManager = formulaManager;
            _warehouseMaterialManager = warehouseMaterialManager;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public override async Task<Plan> InsertAsync(Plan plan)
        {
            var planId = await _planRepository.InsertAndGetIdAsync(plan);
            return GetWithDetails(planId);
        }

        public Plan GetWithDetails(int id)
        {
            var plan = _planRepository.GetAllIncluding()
                .Include(x => x.PlanProducts).ThenInclude(p => p.Product).ThenInclude(f => f.Formulas).ThenInclude(u => u.Unit)
                .Include(x => x.PlanProducts).ThenInclude(p => p.Product).ThenInclude(f => f.Formulas).ThenInclude(m => m.Material)
                .FirstOrDefault(x => x.Id == id);

            return plan;
        }

        public async Task<Plan> GetLastPlanAsync()
        {
            var allplans = await _planRepository.GetAllListAsync();

            if (allplans.Any())
            {
                var lastPlan = allplans.OrderByDescending(x => x.Id).FirstOrDefault();

                if (lastPlan != null)
                {
                    return GetWithDetails(lastPlan.Id);
                }
                else
                {
                    return new Plan();
                }
            }
            else
            {
                return new Plan();
            }            
        }

        public async Task<Plan> GetLastPlanActualAsync()
        {
            var allplans = await _planRepository.GetAllListAsync();

            if (allplans.Any())
            {
                var lastPlanActual = allplans.Where(x=>x.Status == PlanStatus.Actual).OrderByDescending(x => x.Id).FirstOrDefault();

                if (lastPlanActual != null)
                {
                    return GetWithDetails(lastPlanActual.Id);
                }
                else
                {
                    return new Plan();
                }
            }
            else
            {
                return new Plan();
            }
        }

        public Plan UpdatePlan(Plan plan)
        {
            int id = plan.Id;
            using (var unitOfWork = _unitOfWorkManager.Begin())
            {
                var updatedPlan = _planRepository.Update(plan);
                unitOfWork.Complete();
            }
            return GetWithDetails(id);
        }

        public async Task<Plan> ChangeStausToActual(int id)
        {
            var plan = await _planRepository.GetAsync(id);
            plan.Status = PlanStatus.Actual;
            var UpdatedPlan = await _planRepository.UpdateAsync(plan);
            return UpdatedPlan;
        }

        public async Task<Plan> ChangeStausToArchive(int id)
        {
            var plan = await _planRepository.GetAsync(id);
            plan.Status = PlanStatus.Archive;
            var UpdatedPlan = await _planRepository.UpdateAsync(plan);
            return UpdatedPlan;
        }

        public IList<Plan> GetActualPlans()
        {
            var actualPlans = _planRepository.GetAll().Where(x => x.Status == PlanStatus.Actual).ToList();
            return actualPlans;
        }
    }
}
