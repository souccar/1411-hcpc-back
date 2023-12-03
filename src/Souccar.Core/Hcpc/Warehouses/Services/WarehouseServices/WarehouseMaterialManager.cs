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

        public async Task<List<WarehouseMaterial>> GetAllThatWillExpire()
        {
            var generalSetting = await _generalSettingManager.GetAll().FirstOrDefaultAsync();

            var allThatWillExpire = _warehouseMaterialRepository.GetAllIncluding(x=>x.Material)
                .Where(x=>x.ExpirationDate.Date <= DateTime.Now.AddDays(generalSetting.ExpiryDurationNotify).Date && x.Quantity != 0).ToList();

            return allThatWillExpire;
        }
    }
}