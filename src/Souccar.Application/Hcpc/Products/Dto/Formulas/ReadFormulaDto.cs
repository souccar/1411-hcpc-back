using Abp.Application.Services.Dto;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Products.Dto.Products;
using Souccar.Hcpc.Units.Dto.Units;

namespace Souccar.Hcpc.Products.Dto.Formulas
{
    public class ReadFormulaDto : FormulaBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
        public UnitDto Unit { get; set; }
        public MaterialDto Material { get; set; }
    }
}
