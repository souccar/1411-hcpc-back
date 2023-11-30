using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.Hcpc.Products.Services
{
    public class FormulaManager : SouccarDomainService<FormulaItem, int>, IFormulaManager
    {
        public FormulaManager(IRepository<FormulaItem> repository) : base(repository)
        {

        }
    }
}
