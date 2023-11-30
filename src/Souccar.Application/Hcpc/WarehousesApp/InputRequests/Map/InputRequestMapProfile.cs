using AutoMapper;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.WarehousesApp.InputRequests.Dto;

namespace Souccar.Hcpc.WarehousesApp.InputRequests.Map
{
    public class InputRequestMapProfile : Profile
    {
        public InputRequestMapProfile()
        {
            CreateMap<InputRequest, InputRequestDto>();
            CreateMap<InputRequest, ReadInputRequestDto>();
            CreateMap<CreateInputRequestDto, InputRequest>();
            CreateMap<UpdateInputRequestDto, InputRequest>();
            CreateMap<InputRequest, UpdateInputRequestDto>();
        }
    }
}
