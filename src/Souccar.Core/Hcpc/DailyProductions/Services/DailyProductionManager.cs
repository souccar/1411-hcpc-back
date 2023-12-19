using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.Hcpc.Plans.Services;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.Warehouses.Services.OutputRequestServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.DailyProductions.Services
{
    public class DailyProductionManager : SouccarDomainService<DailyProduction, int>, IDailyProductionManager
    {
        private readonly IRepository<DailyProduction> _dailyProductionRepository;
        private readonly IRepository<DailyProductionNote> _dailyProductionNoteRepository;
        private readonly IPlanManager _planManager;
        
        public DailyProductionManager(IRepository<DailyProduction> dailyProductionRepository, IRepository<DailyProductionNote> dailyProductionNoteRepository, IPlanManager planManager) : base(dailyProductionRepository)
        {
            _dailyProductionRepository = dailyProductionRepository;
            _dailyProductionNoteRepository = dailyProductionNoteRepository;
            _planManager = planManager;
        }

        public List<DailyProduction> GetAllIncluding()
        {
            var dailyProductions = _dailyProductionRepository.GetAllIncluding(x => x.DailyProductionNotes).Include(x => x.DailyProductionDetails).ThenInclude(p => p.Product)
               .Include(pl => pl.Plan).ToList();
            return dailyProductions;
        }

        public DailyProduction GetWithDetails(int id)
        {
            var dailyProduction = _dailyProductionRepository.GetAllIncluding(x=>x.DailyProductionNotes).Include(x => x.DailyProductionDetails).ThenInclude(p => p.Product)
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

        public async Task<DailyProductionNote> AddNoteForDailyProductionAsync(string note,int dailyProductionId)
        {
            var newNote = new DailyProductionNote() { DailyProductionId = dailyProductionId,Note = note};
            var createdNoteId = await _dailyProductionNoteRepository.InsertAndGetIdAsync(newNote);
            return await _dailyProductionNoteRepository.GetAsync(createdNoteId);
        }

        public override Task DeleteAsync(int id)
        {
            var relatedOutputRequsts = _planManager.GetAll()
                .SelectMany(x => x.OutputRequests)
                .Any(x => x.Status == OutputRequestStatus.InProduction && x.DailyProductions.Any(y => y.Id == id));

            if (relatedOutputRequsts)
            {
                throw new UserFriendlyException("Cannot be deleted, This daily production is associated with output requests");                
            }
            return base.DeleteAsync(id);

        }
    }
}
