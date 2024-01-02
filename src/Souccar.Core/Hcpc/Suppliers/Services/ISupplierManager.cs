using Souccar.Core.Services.Interfaces;
using Souccar.Hcpc.Materials;
using System.Collections.Generic;

namespace Souccar.Hcpc.Suppliers.Services
{
    public interface ISupplierManager : ISouccarDomainService<Supplier, int>
    {
        List<Supplier> GetSuppliersByMaterialId(int materialId);
    }
}
