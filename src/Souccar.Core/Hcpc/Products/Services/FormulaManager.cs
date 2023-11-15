using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.Hcpc.Products.Services
{
    public class FormulaManager : SouccarDomainService<Formula, int>, IFormulaManager
    {
        public FormulaManager(IRepository<Formula> repository) : base(repository)
        {

        }
    }
}
