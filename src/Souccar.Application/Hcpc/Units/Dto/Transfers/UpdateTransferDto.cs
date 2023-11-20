using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Units.Dto.Transfers
{
    public class UpdateTransferDto : TransferBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
    }
}
