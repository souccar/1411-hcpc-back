using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.Products.Dto.Formulas;
using Souccar.Hcpc.Suppliers.Dto;
using System.Collections.Generic;

namespace Souccar.Hcpc.Formulas.Services.Formulas
{
    public interface IFormulaAppService : IAsyncSouccarAppService<FormulaDto, int, PagedFormulaRequestDto, CreateFormulaDto, UpdateFormulaDto>
    {

        IList<FormulaNameForDropdownDto> GetNameForDropdown();
    }
}
