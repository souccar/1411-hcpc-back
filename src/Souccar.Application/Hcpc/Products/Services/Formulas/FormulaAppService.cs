using Abp.Authorization;
using Souccar.Authorization;
using Souccar.Core.Services;
using Souccar.Hcpc.Products;
using Souccar.Hcpc.Products.Dto.Formulas;
using Souccar.Hcpc.Products.Services;

namespace Souccar.Hcpc.Formulas.Services.Formulas
{
    [AbpAuthorize(PermissionNames.Setting_Products)]
    public class FormulaAppService : AsyncSouccarAppService<FormulaItem, FormulaDto, int, PagedFormulaRequestDto, CreateFormulaDto, UpdateFormulaDto>, IFormulaAppService
    {
        private readonly IFormulaManager _formulaDomainService;
        public FormulaAppService(IFormulaManager formulaDomainService) : base(formulaDomainService)
        {
            _formulaDomainService = formulaDomainService;
        }

        //public IList<FormulaNameForDropdownDto> GetNameForDropdown()
        //{
        //    return _formulaDomainService.GetAll()
        //        .Select(x => new FormulaNameForDropdownDto(x.Id, x.Name)).ToList();
        //}
    }
}
