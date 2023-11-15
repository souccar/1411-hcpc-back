using AutoMapper;
using Souccar.Hcpc.InputRequests.Dto;
using Souccar.Hcpc.Warehouses;

namespace Souccar.Hcpc.InputRequests.Map
{
    public class InputRequestMapProfile: Profile
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
