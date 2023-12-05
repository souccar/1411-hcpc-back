using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.Hcpc.GeneralSettings.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Warehouses.Services.WarehouseServices
{
    public class WarehouseMaterialManager : SouccarDomainService<WarehouseMaterial, int>, IWarehouseMaterialManager
    {
        private readonly IRepository<WarehouseMaterial> _warehouseMaterialRepository;
        private readonly IGeneralSettingManager _generalSettingManager;

        public WarehouseMaterialManager(IRepository<WarehouseMaterial> warehouseMaterialRepository, IGeneralSettingManager generalSettingManager): base(warehouseMaterialRepository)
        {
            _warehouseMaterialRepository = warehouseMaterialRepository;
            _generalSettingManager = generalSettingManager;
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
                await _warehouseMaterialRepository.EnsurePropertyLoadedAsync(warehouseMaterial, up => up.UnitPrice);
                await _warehouseMaterialRepository.EnsurePropertyLoadedAsync(warehouseMaterial, u => u.Unit);
            }
            
            return warehouseMaterial;
        }

        public async Task<List<WarehouseMaterial>> GetAllThatWillExpire()
        {
            var generalSetting = await _generalSettingManager.GetAll().FirstOrDefaultAsync();

            var allThatWillExpire = _warehouseMaterialRepository.GetAllIncluding(x => x.Material)
                .Where(x => x.ExpirationDate.Date <= DateTime.Now.AddDays(generalSetting.ExpiryDurationNotify).Date &&
                x.CurrentQuantity != 0 && !x.AboutToFinish).ToList();

            return allThatWillExpire;
        }

    }
}