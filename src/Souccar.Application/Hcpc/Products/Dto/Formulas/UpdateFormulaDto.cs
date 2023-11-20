using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Products.Dto.Formulas
{
    public class UpdateFormulaDto : EntityDto<int>
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public int MaterialId { get; set; }
        public int UnitId { get; set; }
        public int ProductId { get; set; }
    }
}
