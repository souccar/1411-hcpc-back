using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using System.Collections.Generic;
using System.Linq;

namespace Souccar.Hcpc.Products.Services
{
    public class ProductManager : SouccarDomainService<Product, int>, IProductManager
    {
        private readonly IRepository<Product> _productRepository;
        public ProductManager(IRepository<Product> productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
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

    }
}
