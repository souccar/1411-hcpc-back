using Abp.Domain.Repositories;
using Abp.UI;
using Souccar.Core.Services.Implements;
using Souccar.Hcpc.Products.Services;
using Souccar.Hcpc.Warehouses.Services.WarehouseServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Units.Services
{
    public class UnitManager : SouccarDomainService<Unit, int>, IUnitManager
    {
        private readonly IRepository<Unit> _unitRepository;
        private readonly IWarehouseMaterialManager _warehouseMaterialManager;
        private readonly ITransferManager _transferManager;
        private readonly IProductManager _productManager;

        public UnitManager(IRepository<Unit> unitRepository,
            IWarehouseMaterialManager warehouseMaterialManager,
            ITransferManager transferManager,
            IProductManager productManager): base(unitRepository)
        {
            _unitRepository = unitRepository;
            _warehouseMaterialManager = warehouseMaterialManager;
            _transferManager = transferManager;
            _productManager = productManager;
        }

        public override Task DeleteAsync(int id)
        {
            var relatedWarehouseMaterials = _warehouseMaterialManager.GetAll().Any(x => x.UnitId == id);
            var relatedTransfers = _transferManager.GetAll().Any(x => x.FromId == id || x.ToId == id);
            var relatedProductss = _productManager.GetAll().Any(x => x.Formulas.Any(y=>y.UnitId == id));

            if (relatedWarehouseMaterials || relatedTransfers || relatedProductss)
            {
                throw new UserFriendlyException("Cannot be deleted, there are associates");
            }
            return base.DeleteAsync(id);
        }

        public async Task<IList<Unit>> GetAllParentUnitsAsync()
        {
            var units = await Task.FromResult(_unitRepository.GetAll().Where(x=>x.ParentUnitId== null).ToList());
            return units;
        }

        public async Task<IList<Unit>> GetAllRelatedUnitsAsync(int id)
        {
            var units = new List<Unit>();
            var currentUnit = await GetIncludeParentAsync(id);
            if(currentUnit.ParentUnit != null)
            {
                units.Add(currentUnit.ParentUnit);
                var relatedUnits = await Task.FromResult(_unitRepository.GetAll()
                .Where(x => x.Id != currentUnit.Id && x.ParentUnitId == currentUnit.ParentUnitId).ToList());
                if (relatedUnits.Any())
                {
                    units.AddRange(relatedUnits);
                }                
            }
            else
            {
                var childrenUnits = await Task.FromResult(_unitRepository.GetAll()
                .Where(x => x.ParentUnitId == currentUnit.Id).ToList());
                if (childrenUnits.Any())
                {
                    units.AddRange(childrenUnits);
                }
            }            
            return units;
        }

        public async Task<Unit> GetIncludeParentAsync(int id)
        {
            var unit = await _unitRepository.GetAsync(id);
            if(unit != null)
            {
                await _unitRepository.EnsurePropertyLoadedAsync(unit, x => x.ParentUnit);
            }
            return unit;
        }
    }
}
