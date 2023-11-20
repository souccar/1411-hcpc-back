using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Suppliers.Dto
{
    public class ReadSupplierDto : SupplierBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
        
    }
}
