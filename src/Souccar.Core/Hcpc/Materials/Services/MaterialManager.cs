using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.Hcpc.Plans;
using System.Linq;

namespace Souccar.Hcpc.Materials.Services
{
    public class MaterialManager: SouccarDomainService<Material, int>, IMaterialManager
    {
        private readonly IRepository<Material> _materialRepository;
        public MaterialManager(IRepository<Material> repository, IRepository<Material> materialRepository) : base(repository)
        {
            _materialRepository = materialRepository;
        }

        public Material GetWithDetails(int id)
        {
            var material = _materialRepository.GetAllIncluding().Include(x=>x.Suppliers).ThenInclude(y=>y.Supplier).FirstOrDefault(x=>x.Id== id);

            return material;
        }
    }
}
