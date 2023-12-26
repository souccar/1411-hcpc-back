using Souccar.Consts;
using Souccar.Hcpc.Plans.Dto.PlanProducts;
using Souccar.Validation.Date;
using Souccar.Validation.List;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.Plans.Dto.Plans
{
    public class CreatePlanDto
    {
        public CreatePlanDto()
        {
            PlanProducts = new List<CreatePlanProductDto>();
        }

        [Required(ErrorMessage = SouccarAppConstant.Required, AllowEmptyStrings = false), MaxLength(SouccarAppConstant.SimpleStringMaxLength)]
        public string Title { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required), Range(0, double.PositiveInfinity, ErrorMessage = SouccarAppConstant.LessThanZero)]
        public int Duration { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required), ParseToDate(ErrorMessage = SouccarAppConstant.InvalidDate)]
        public string StartDate { get; set; }

        [NotEmptyList(ErrorMessage = SouccarAppConstant.EmptyList)]
        public IList<CreatePlanProductDto> PlanProducts { get; set; }
    }
}
