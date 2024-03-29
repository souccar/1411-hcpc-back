﻿using Souccar.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Materials.Services
{
    public interface IMaterialManager : ISouccarDomainService<Material, int>
    {
        Material GetWithDetails(int id);
        IList<MaterialSuppliers> GetMaterialsOfSupplier(int materialId);
        Task<List<Material>> GetByProductsIds(int[] productsIds);
    }
}
