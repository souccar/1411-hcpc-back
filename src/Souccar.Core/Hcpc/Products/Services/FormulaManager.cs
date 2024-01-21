using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Products.Services
{
    public class FormulaManager : SouccarDomainService<FormulaItem, int>, IFormulaManager
    {
        private readonly IRepository<FormulaItem> _formulaRepository;
        public FormulaManager(IRepository<FormulaItem> repository, IRepository<FormulaItem> formulaRepository) : base(repository)
        {
            _formulaRepository = formulaRepository;
        }

        public async Task<FormulaItem> GetFirstByMaterialId(int materialId)
        {
            var formula = await _formulaRepository.FirstOrDefaultAsync(x => x.MaterialId == materialId);
            return formula;
        }
    }
}
