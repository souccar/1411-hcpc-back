using Abp.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Souccar.Hcpc.Units;
using System.Linq;

namespace Souccar.EntityFrameworkCore.Seed.Host
{
    public class DefaultUnitsCreator
    {
        private readonly SouccarDbContext _context;

        public DefaultUnitsCreator(SouccarDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUnits();
        }

        private void CreateUnits()
        {
            int? tenantId = null;

            if (SouccarConsts.MultiTenancyEnabled == false)
            {
                tenantId = MultiTenancyConsts.DefaultTenantId;
            }

            AddUnitIfNotExists("kg", tenantId);
            AddUnitIfNotExists("g", tenantId);
            AddUnitIfNotExists("l", tenantId);
            AddUnitIfNotExists("ml", tenantId);
        }

        private void AddUnitIfNotExists(string name, int? tenantId = null)
        {
            if (_context.Units.IgnoreQueryFilters().Any(s => s.Name.ToLower().Equals(name) && s.TenantId == tenantId))
            {
                return;
            }

            _context.Units.Add(new Unit() { Name = name, TenantId = tenantId });
            _context.SaveChanges();
        }
    }
}
