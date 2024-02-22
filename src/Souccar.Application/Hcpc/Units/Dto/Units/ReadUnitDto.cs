using Abp.Application.Services.Dto;
using Souccar.Core.CustomAttributes;

namespace Souccar.Hcpc.Units.Dto.Units
{
    public class ReadUnitDto : EntityDto<int>
    {
        [ReadUserInterface(Searchable = true)]
        public string Name { get; set; }

        public int? ParentUnitId { get; set; }
        public ParentUnitDto ParentUnit { get; set; }
    }
}
