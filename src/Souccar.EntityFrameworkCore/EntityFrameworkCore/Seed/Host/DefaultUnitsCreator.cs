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

            AddUnitIfNotExists("tones", tenantId);
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

            if(name == "kg")
            {
                var unit = _context.Units.FirstOrDefault(s => s.Name.ToLower() == "tones");
                if(unit != null)
                {
                    _context.Units.Add(new Unit() { Name = name, TenantId = tenantId,ParentUnitId =  unit.Id});
                }
            }
            else if (name == "g")
            {
                var unit = _context.Units.FirstOrDefault(s => s.Name.ToLower() == "tones");
                if (unit != null)
                {
                    _context.Units.Add(new Unit() { Name = name, TenantId = tenantId, ParentUnitId = unit.Id });
                }
            }
            else if (name == "ml")
            {
                var unit = _context.Units.FirstOrDefault(s => s.Name.ToLower() == "l");
                if (unit != null)
                {
                    _context.Units.Add(new Unit() { Name = name, TenantId = tenantId, ParentUnitId = unit.Id });
                }
            }
            else
            {
                _context.Units.Add(new Unit() { Name = name, TenantId = tenantId, ParentUnitId = null});
            }

            _context.SaveChanges();
        }
    }
}
