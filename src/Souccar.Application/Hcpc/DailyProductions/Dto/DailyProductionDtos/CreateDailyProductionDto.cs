using Souccar.Consts;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionDetailsDtos;
using Souccar.Validation.List;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.DailyProductions.Dto.DailyProductionDtos
{
    public class CreateDailyProductionDto
    {
        public CreateDailyProductionDto()
        {
            DailyProductionDetails = new List<CreateDailyProductionDetailsDto>();
        }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? PlanId { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? OutputRequestId { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required, AllowEmptyStrings = false), MaxLength(SouccarAppConstant.MultiLinesStringMaxLength)]
        public string Note { get; set; }

        [NotEmptyList(ErrorMessage = SouccarAppConstant.EmptyList)]
        public IList<CreateDailyProductionDetailsDto> DailyProductionDetails { get; set; }
    }
}
