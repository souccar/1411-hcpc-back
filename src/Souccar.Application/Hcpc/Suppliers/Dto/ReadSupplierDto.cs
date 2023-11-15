using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Suppliers.Dto
{
    public class ReadSupplierDto : SupplierDto, IEntityDto<int>
    {
        public int Id { get; set; }
        
    }
}
