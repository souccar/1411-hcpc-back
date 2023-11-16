using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Products.Dto.Formulas
{
    public class UpdateFormulaDto : FormulaBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
    }
}
