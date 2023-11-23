using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using System.Collections.Generic;
using System.Linq;

namespace Souccar.Hcpc.DailyProductions.Services
{
    public class DailyProductionManager : SouccarDomainService<DailyProduction, int>, IDailyProductionManager
    {
        private readonly IRepository<DailyProduction> _dailyProductionRepository;

        public DailyProductionManager(IRepository<DailyProduction> dailyProductionRepository) : base(dailyProductionRepository)
        {
            _dailyProductionRepository = dailyProductionRepository;
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
                .Include(pl=>pl.Plan)
                .FirstOrDefault(x=>x.Id == id);
            return dailyProduction;
        }
    }
}
