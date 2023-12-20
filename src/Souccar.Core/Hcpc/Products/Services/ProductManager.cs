using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.Hcpc.Plans.Services;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.Warehouses.Services.OutputRequestServices;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Products.Services
{
    public class ProductManager : SouccarDomainService<Product, int>, IProductManager
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IPlanManager _planManager;
        private readonly IOutputRequestManager _outputRequestManager;

        public ProductManager(IRepository<Product> productRepository, IPlanManager planManager, IOutputRequestManager outputRequestManager) : base(productRepository)
        {
            _productRepository = productRepository;
            _planManager = planManager;
            _outputRequestManager = outputRequestManager;
        }

        public IQueryable<Product> GetWithFormula(int[] ids)
        {
            return _productRepository.GetAll().Where(x => ids.Contains(x.Id))
                .Include(f => f.Formulas).ThenInclude(u => u.Unit)
                .Include(f => f.Formulas).ThenInclude(m => m.Material);
        }

        public IQueryable<Product> GetProductsFromMaterial(int materialId)
        {
           
            return GetAllWithIncluding("Formulas").Where(x => x.Formulas.Select(y => y.MaterialId).Contains(materialId));
           
        }

        public override Task DeleteAsync(int id)
        {
            var relatedOutputRequests = _outputRequestManager.GetAll()
                .Where(x=>x.Status != OutputRequestStatus.Finished)
                .SelectMany(y=>y.OutputRequestProducts)
                .Any(z=>z.ProductId== id);           
            if (relatedOutputRequests)
            {
                throw new UserFriendlyException("Cannot be deleted, This product is associated with output requests not finished");
            }

            var relatedPlanProducts = _planManager.GetAll()
                .Where(x => x.Status != Plans.PlanStatus.Archive)
                .SelectMany(y => y.PlanProducts)
                .Any(z => z.ProductId == id);
             if (relatedPlanProducts)
             {
                throw new UserFriendlyException("Cannot be deleted, This product is associated with plans not archived");
             }
            return base.DeleteAsync(id);
        }
    }
}
