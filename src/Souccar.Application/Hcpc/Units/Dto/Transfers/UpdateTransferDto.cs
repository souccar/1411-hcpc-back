using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Units.Dto.Transfers
{
    public class UpdateTransferDto : TransferDto, IEntityDto<int>
    {
        public int Id { get; set; }
    }
}
