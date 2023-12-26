using Abp.Application.Services.Dto;
using Souccar.Consts;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.DailyProductions.Dto.DailyProductionDetailsDtos
{
    public class UpdateDailyProductionDetailsDto : EntityDto<int>
    {
        [Required(ErrorMessage = SouccarAppConstant.Required), Range(0, double.PositiveInfinity, ErrorMessage = SouccarAppConstant.LessThanZero)]
        public int Quantity { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? ProductId { get; set; }
    }
}
