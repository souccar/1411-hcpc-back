using Abp.Application.Services.Dto;
using Souccar.Core.CustomAttributes;
using Souccar.Hcpc.Units.Dto.Units;

namespace Souccar.Hcpc.Units.Dto.Transfers
{
    public class ReadTransferDto : EntityDto<int>
    {
        [ReadUserInterface(Searchable = true)]
        public UnitDto From { get; set; }
        [ReadUserInterface(Searchable = true)]
        public UnitDto To { get; set; }
    }
}
