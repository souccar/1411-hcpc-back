using Souccar.Consts;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.GeneralSettings.Dto
{
    public class CreateGeneralSettingDto
    {

        [Required(ErrorMessage = SouccarAppConstant.Required), Range(0, double.PositiveInfinity, ErrorMessage = SouccarAppConstant.LessThanZero)]
        public int ExpiryDurationNotify { get; set; }
    }
}
