using AutoMapper;
using Souccar.Hcpc.Units;
using Souccar.Hcpc.Units.Dto.Transfers;

namespace Souccar.Hcpc.Transfers.Map
{
    public class TransferMapProfile : Profile
    {
        public TransferMapProfile()
        {
            CreateMap<Transfer, TransferDto>();
            CreateMap<Transfer, ReadTransferDto>();
            CreateMap<CreateTransferDto, Transfer>();
            CreateMap<UpdateTransferDto, Transfer>();
            CreateMap<Transfer, UpdateTransferDto>();
        }
    }
}
