using Abp.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Souccar.Hcpc.Units;
using System.Linq;

namespace Souccar.EntityFrameworkCore.Seed.Host
{
    public class DefaultTransfersCreator
    {
        private readonly SouccarDbContext _context;

        public DefaultTransfersCreator(SouccarDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateTransfers();
        }

        private void CreateTransfers()
        {
            int? tenantId = null;

            if (SouccarConsts.MultiTenancyEnabled == false)
            {
                tenantId = MultiTenancyConsts.DefaultTenantId;
            }

            AddTransferIfNotExists("kg", "g", 1000, tenantId);
            AddTransferIfNotExists("l", "ml", 1000, tenantId);
        }

        private void AddTransferIfNotExists(string fromUnit, string toUnit, double value, int? tenantId = null)
        {
            var from = _context.Units.IgnoreQueryFilters().FirstOrDefault(x => x.Name.ToLower().Equals(fromUnit));
            var to = _context.Units.IgnoreQueryFilters().FirstOrDefault(x => x.Name.ToLower().Equals(toUnit));

            if (from == null || to == null)
                return;

            if (_context.Transfers.IgnoreQueryFilters()
                .Any(s => s.FromId == from.Id && s.ToId == to.Id && s.TenantId == tenantId))
            {
                return;
            }

            _context.Transfers.Add(new Transfer() { FromId = from.Id, ToId = to.Id, Value = value, TenantId = tenantId });
            _context.SaveChanges();
        }
    }
}
