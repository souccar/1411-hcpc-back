using Souccar.Core.Services;
using Souccar.Hcpc.Products.Dto.Formulas;

namespace Souccar.Hcpc.Formulas.Services.Formulas
{
    public interface IFormulaAppService : IAsyncSouccarAppService<FormulaDto, int, PagedFormulaRequestDto, CreateFormulaDto, UpdateFormulaDto>
    {
        //IList<FormulaNameForDropdownDto> GetNameForDropdown();
    }
}
