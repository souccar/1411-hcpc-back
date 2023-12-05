using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.Hcpc.Plans;
using Souccar.Hcpc.Plans.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.DailyProductions.Services
{
    public class DailyProductionManager : SouccarDomainService<DailyProduction, int>, IDailyProductionManager
    {
        private readonly IRepository<DailyProduction> _dailyProductionRepository;
        private readonly IPlanManager _planManager;

        public DailyProductionManager(IRepository<DailyProduction> dailyProductionRepository, IPlanManager planManager) : base(dailyProductionRepository)
        {
            _dailyProductionRepository = dailyProductionRepository;
            _planManager = planManager;
        }

        public List<DailyProduction> GetAllIncluding()
        {
            var dailyProductions = _dailyProductionRepository.GetAllIncluding().Include(x => x.DailyProductionDetails).ThenInclude(p => p.Product)
               .Include(pl => pl.Plan).ToList();
            return dailyProductions;
        }


        public DailyProduction GetWithDetails(int id)
        {
            var dailyProduction = _dailyProductionRepository.GetAllIncluding().Include(x => x.DailyProductionDetails).ThenInclude(p => p.Product)
                .Include(pl => pl.Plan)
                .FirstOrDefault(x => x.Id == id);
            return dailyProduction;
        }

        public Dictionary<int, int> GetAllProductionsCountForPlan(int PlanId)
        {
            Dictionary<int, int> allProductionsForPlan = new Dictionary<int, int>();
            var plan = _planManager.GetWithDetails(PlanId);

            var dailyProductionsForCurrentPlan = _dailyProductionRepository.GetAllIncluding()
                .Include(x=>x.DailyProductionDetails).ThenInclude(p=>p.Product)
                .Where(x => x.PlanId == PlanId).ToList();

            foreach (var planProduct in plan.PlanProducts)
            {
                if (!allProductionsForPlan.ContainsKey((int)planProduct.ProductId))
                {
                    allProductionsForPlan.Add((int)planProduct.ProductId, 0);
                }
            }

            foreach (var dailyProduction in dailyProductionsForCurrentPlan)
            {
                foreach (var dailyProductionDetail in dailyProduction.DailyProductionDetails)
                {
                    if (allProductionsForPlan.ContainsKey((int)dailyProductionDetail.ProductId))
                    {
                        allProductionsForPlan[(int)dailyProductionDetail.ProductId] += dailyProductionDetail.Quantity;
                    }
                    
                }
            }

            return allProductionsForPlan;
        }
    }
}
