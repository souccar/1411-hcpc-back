using Abp.Application.Services.Dto;
using Souccar.Consts;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.WarehousesApp.Warehouses.Dto
{
    public class UpdateWarehouseDto : EntityDto<int>
    {

        [Required(ErrorMessage = SouccarAppConstant.Required, AllowEmptyStrings = false), MaxLength(SouccarAppConstant.SimpleStringMaxLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required, AllowEmptyStrings = false), MaxLength(SouccarAppConstant.SimpleStringMaxLength)]
        public string Place { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public long? WarehouseKeeperId { get; set; }
    }
}
