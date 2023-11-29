using AutoMapper;
using Souccar.Hcpc.Products;
using Souccar.Hcpc.Products.Dto.Formulas;

namespace Souccar.Hcpc.Formulas.Map
{
    public class FormulaMapProfile : Profile
    {
        public FormulaMapProfile()
        {
            CreateMap<FormulaItem, FormulaDto>();
            CreateMap<FormulaItem, ReadFormulaDto>();
            CreateMap<CreateFormulaDto, FormulaItem>();
            CreateMap<UpdateFormulaDto, FormulaItem>();
            CreateMap<FormulaItem, UpdateFormulaDto>();
        }
    }
}
