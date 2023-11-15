using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Suppliers.Dto
{
    public class SupplierDto : SupplierBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }

    }
}
