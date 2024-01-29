using Abp.Application.Services.Dto;
using Souccar.Core.CustomAttributes;

namespace Souccar.Hcpc.Suppliers.Dto
{
    public class ReadSupplierDto  : EntityDto<int>
    {
        [ReadUserInterface(Searchable = true)]
        public string Name { get; set; }
        public string Description { get; set; }

}
}
