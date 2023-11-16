using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Suppliers.Dto
{
    public class SupplierNameForDropdownDto : EntityDto<int>
    {
        public SupplierNameForDropdownDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public string Name { get; set; }
    }
}
