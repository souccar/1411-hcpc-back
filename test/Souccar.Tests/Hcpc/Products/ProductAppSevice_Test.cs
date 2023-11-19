using Souccar.Hcpc.Formulas.Services.Formulas;
using Souccar.Hcpc.Products.Dto.Products;
using Souccar.Hcpc.Products.Services.Products;
using Souccar.Hcpc.Units.Dto.Units;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Souccar.Tests.Hcpc.Products
{
    public class ProductAppSevice_Test : SouccarTestBase
    {
        private readonly IProductAppService _productAppService;
        private readonly IFormulaAppService _formulaAppService;

        public ProductAppSevice_Test()
        {
            _productAppService = Resolve<IProductAppService>();
            _formulaAppService = Resolve<IFormulaAppService>();
        }

        [Fact]
        public async Task CreateProduct()
        {
            //Get all units
            var pagedRequest = new PagedProductRequestDto();
            pagedRequest.MaxResultCount = 100;
            pagedRequest.SkipCount = 0;
            var products = await _productAppService.GetAllAsync(pagedRequest);

            ProductDto product = null;
            if (products.TotalCount > 0)
            {
                product = products.Items.Where(x => x.Name.ToLower().Equals("PreSun Oily")).FirstOrDefault();
            }

            if (product == null)
            {
                var input = new CreateProductDto();
                input.Name = "PreSun Oily";
                product = await _productAppService.CreateAsync(input);
            }
            
        }
    }
}
