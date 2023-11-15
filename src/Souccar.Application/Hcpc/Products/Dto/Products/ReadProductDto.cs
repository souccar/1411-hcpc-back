using Abp.Application.Services.Dto;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Units.Dto.Units;

namespace Souccar.Hcpc.Products.Dto.Products
{
    public class ReadProductDto : ProductBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
    }
}
