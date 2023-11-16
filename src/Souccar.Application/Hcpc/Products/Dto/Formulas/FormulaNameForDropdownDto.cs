using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Products.Dto.Formulas
{
    public class FormulaNameForDropdownDto : EntityDto<int>
    {
        public FormulaNameForDropdownDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public string Name { get; set; }
    }
}
