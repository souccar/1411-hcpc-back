using Abp.Application.Services.Dto;
using Souccar.Consts;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.Units.Dto.Units
{
    public class UpdateUnitDto : EntityDto<int>
    {
        [Required(ErrorMessage = SouccarAppConstant.Required ,AllowEmptyStrings = false), MaxLength(SouccarAppConstant.SimpleStringMaxLength)]
        public string Name { get; set; }

        public int? ParentUnitId { get; set; }
    }
}
