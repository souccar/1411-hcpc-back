using Abp.Application.Services.Dto;
using Souccar.Hcpc.Products.Dto.Products;

namespace Souccar.Hcpc.Products.Dto.Formulas
{
    public class UpdateFormulaDto : FormulaBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
    }
}
