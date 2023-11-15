using AutoMapper;
using Souccar.Hcpc.Products;
using Souccar.Hcpc.Products.Dto.Formulas;

namespace Souccar.Hcpc.Formulas.Map
{
    public class FormulaMapProfile : Profile
    {
        public FormulaMapProfile()
        {
            CreateMap<Formula, FormulaDto>();
            CreateMap<Formula, ReadFormulaDto>();
            CreateMap<CreateFormulaDto, Formula>();
            CreateMap<UpdateFormulaDto, Formula>();
            CreateMap<Formula, UpdateFormulaDto>();
        }
    }
}
