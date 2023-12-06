using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.Units.Dto.Transfers
{
    public class TransferToGreaterUnitInputDto
    {
        public TransferToGreaterUnitInputDto()
        {
            
        }
        public TransferToGreaterUnitInputDto(int? unitId, double value)
        {
            UnitId = unitId;
            Value = value;
        }

        [Required]
        public int? UnitId { get; set; }

        [Required]
        public double Value { get; set; }
    }
}
