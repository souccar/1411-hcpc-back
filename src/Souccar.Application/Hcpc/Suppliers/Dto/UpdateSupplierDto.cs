using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Suppliers.Dto
{
    public class UpdateSupplierDto : SupplierBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
    }
}
