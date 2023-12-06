using Abp.Application.Services.Dto;
using Souccar.Hcpc.Units.Dto.Units;

namespace Souccar.Hcpc.Units.Dto.Transfers
{
    public class TransferToGreaterUnitOutputDto 
    {
        public TransferToGreaterUnitOutputDto(double value, int? unitId, UnitDto unit = null)
        {
            Value = value;
            UnitId = unitId;
            Unit = unit;
        }

        public double Value { get; set; }

        public int? UnitId { get; set; }
        public UnitDto Unit { get; set; }

    }
}
