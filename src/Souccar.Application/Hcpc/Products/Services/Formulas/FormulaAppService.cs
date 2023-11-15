using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.Products;
using Souccar.Hcpc.Products.Dto.Formulas;
using Souccar.Hcpc.Products.Services;
namespace Souccar.Hcpc.Formulas.Services.Formulas
{
    public class FormulaAppService : AsyncSouccarAppService<Formula, FormulaDto, int, PagedFormulaRequestDto, CreateFormulaDto, UpdateFormulaDto, FormulaDto, EntityDto<int>>, IFormulaAppService
    {
        private readonly IFormulaManager _formulaDomainService;
        public FormulaAppService(IFormulaManager formulaDomainService) : base(formulaDomainService)
        {
            _formulaDomainService = formulaDomainService;
        }
    }
}
