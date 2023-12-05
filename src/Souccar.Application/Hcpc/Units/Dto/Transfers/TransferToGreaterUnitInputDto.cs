using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.Units.Dto.Transfers
{
    public class TransferToGreaterUnitInputDto
    {
        [Required]
        public int UnitId { get; set; }

        [Required]
        public double Value { get; set; }
    }
}
