using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.Products;
using Souccar.Hcpc.Products.Dto.Formulas;
using Souccar.Hcpc.Products.Services;
using System.Collections.Generic;
using System.Linq;

namespace Souccar.Hcpc.Formulas.Services.Formulas
{
    public class FormulaAppService : AsyncSouccarAppService<FormulaItem, FormulaDto, int, PagedFormulaRequestDto, CreateFormulaDto, UpdateFormulaDto>, IFormulaAppService
    {
        private readonly IFormulaManager _formulaDomainService;
        public FormulaAppService(IFormulaManager formulaDomainService) : base(formulaDomainService)
        {
            _formulaDomainService = formulaDomainService;
        }

        public IList<FormulaNameForDropdownDto> GetNameForDropdown()
        {
            return _formulaDomainService.GetAll()
                .Select(x => new FormulaNameForDropdownDto(x.Id, x.Name)).ToList();
        }
    }
}
