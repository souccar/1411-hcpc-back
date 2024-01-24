using Souccar.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Products.Services
{
    public interface IFormulaManager : ISouccarDomainService<FormulaItem, int>
    {
        Task<FormulaItem> GetFirstByMaterialId(int materialId);
    }
}
