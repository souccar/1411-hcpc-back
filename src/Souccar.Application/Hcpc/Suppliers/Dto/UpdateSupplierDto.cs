using Abp.Application.Services.Dto;
using Souccar.Consts;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.Suppliers.Dto
{
    public class UpdateSupplierDto :EntityDto<int>
    {
        [Required(ErrorMessage = SouccarAppConstant.Required, AllowEmptyStrings = false), MaxLength(SouccarAppConstant.SimpleStringMaxLength)]
        public string Name { get; set; }

        [MaxLength(SouccarAppConstant.MultiLinesStringMaxLength)]
        public string Description { get; set; }
    }
}
