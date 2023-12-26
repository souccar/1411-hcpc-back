using Abp.Application.Services.Dto;
using Souccar.Consts;
using System;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.Units.Dto.Transfers
{
    public class UpdateTransferDto : EntityDto<int>
    {
        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int FromId { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int ToId { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required), Range(0, double.PositiveInfinity, ErrorMessage = SouccarAppConstant.LessThanZero)]
        public double Value { get; set; }
    }
}
