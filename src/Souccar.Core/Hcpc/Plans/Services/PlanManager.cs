using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.Hcpc.Products.Services;
using Souccar.Hcpc.Warehouses.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Plans.Services
{
    public class PlanManager : SouccarDomainService<Plan, int>, IPlanManager
    {
        private readonly IRepository<Plan> _planRepository;
        private readonly IFormulaManager _formulaManager;
        private readonly IWarehouseMaterialManager _warehouseMaterialManager;

        public PlanManager(
            IRepository<Plan> planRepository, 
            IFormulaManager formulaManager,
            IWarehouseMaterialManager warehouseMaterialManager) : base(planRepository)
        {
            _planRepository = planRepository;
            _formulaManager = formulaManager;
            _warehouseMaterialManager = warehouseMaterialManager;
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

        public Plan UpdatePlan(Plan plan)
        {
            var Update = _planRepository.Update(plan);
            return Update;
        }
    }
}
