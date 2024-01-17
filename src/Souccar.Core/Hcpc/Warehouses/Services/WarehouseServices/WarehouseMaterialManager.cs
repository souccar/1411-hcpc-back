using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.Hcpc.GeneralSettings.Services;
using Souccar.Hcpc.Warehouses.Services.OutputRequestServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Warehouses.Services.WarehouseServices
{
    public class WarehouseMaterialManager : SouccarDomainService<WarehouseMaterial, int>, IWarehouseMaterialManager
    {
        private readonly IRepository<WarehouseMaterial> _warehouseMaterialRepository;
        private readonly IGeneralSettingManager _generalSettingManager;
        private readonly IOutputRequestManager _outputRequestManager;

        public WarehouseMaterialManager(IRepository<WarehouseMaterial> warehouseMaterialRepository,
            IGeneralSettingManager generalSettingManager,
            IOutputRequestManager outputRequestManager) : base(warehouseMaterialRepository)
        {
            _warehouseMaterialRepository = warehouseMaterialRepository;
            _generalSettingManager = generalSettingManager;
            _outputRequestManager = outputRequestManager;
        }

        public override Task<WarehouseMaterial> InsertAsync(WarehouseMaterial input)
        {
            input.CurrentQuantity = input.InitialQuantity;
            return base.InsertAsync(input);
        }

        public async Task<WarehouseMaterial> GetWithDetailsAsync(int id)
        {
            var warehouseMaterial = await _warehouseMaterialRepository.GetAsync(id);            

            if (warehouseMaterial != null)
            {
                await _warehouseMaterialRepository.EnsurePropertyLoadedAsync(warehouseMaterial, w => w.Warehouse);
                await _warehouseMaterialRepository.EnsurePropertyLoadedAsync(warehouseMaterial, s => s.Supplier);
                await _warehouseMaterialRepository.EnsurePropertyLoadedAsync(warehouseMaterial, m => m.Material);
                //await _warehouseMaterialRepository.EnsurePropertyLoadedAsync(warehouseMaterial, up => up.UnitPrice);
                await _warehouseMaterialRepository.EnsurePropertyLoadedAsync(warehouseMaterial, u => u.Unit);
            }
            
            return warehouseMaterial;
        }

        public async Task<List<WarehouseMaterial>> GetAllThatWillExpire()
        {
            var generalSetting = await _generalSettingManager.GetAll().FirstOrDefaultAsync();

            if (generalSetting != null)
            {
                var allThatWillExpire = _warehouseMaterialRepository.GetAllIncluding(x => x.Material)
                .Where(x => x.ExpirationDate.Date <= DateTime.Now.AddDays(generalSetting.ExpiryDurationNotify).Date &&
                x.CurrentQuantity != 0 && !x.AboutToFinish).ToList();

                return allThatWillExpire;
            }
            else
            {
                throw new UserFriendlyException("You must add general setting");
            }           

            
        }

        public override Task DeleteAsync(int id)
        {
            var relatedOutputRequests = _outputRequestManager.GetAll()
                .Any(x => x.Status != OutputRequestStatus.Finished && x.OutputRequestMaterials.Any(y => y.WarehouseMaterialId == id));
            if (relatedOutputRequests)
            {
                throw new UserFriendlyException("Cannot be deleted, This warehouse material is associated with output requests");
            }
            return base.DeleteAsync(id);
        }

        public async Task<List<WarehouseMaterial>> GetByMaterialIdAsync(int materialId)
        {
            var warehouseMaterials = await Task.FromResult(_warehouseMaterialRepository.GetAllIncluding(x=>x.Warehouse)
                .Where(x=>x.MaterialId == materialId).ToList());
            return warehouseMaterials;
        }

        public async Task<List<WarehouseMaterial>> GetWithWarehouseNameAndExpiryDate()
        {
            var warehouseMaterials = await Task.FromResult(_warehouseMaterialRepository.GetAllIncluding(x => x.Warehouse).ToList());
            return warehouseMaterials;
        }
    }
}