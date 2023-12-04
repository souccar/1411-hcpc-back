namespace Souccar.Hcpc.Products.Dto.Products
{
    public class ProductCostDto
    {
        public int ProductId { get; set; }

        /// <summary>
        /// تكلفة إنتاج عبوة واحدة من المنتج الحالي
        /// </summary>
        public double CostOfProduction { get; set; }
    }
}
