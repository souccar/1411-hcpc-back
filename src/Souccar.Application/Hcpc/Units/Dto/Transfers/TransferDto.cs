using Abp.Application.Services.Dto;
using Souccar.Hcpc.Units.Dto.Units;

namespace Souccar.Hcpc.Units.Dto.Transfers
{
    public class TransferDto : TransferBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
        public UnitDto From { get; set; }
        public UnitDto To { get; set; }
    }
}
