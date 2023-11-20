using AutoMapper;
using Souccar.Hcpc.InputRequests.Dto;
using Souccar.Hcpc.Warehouses;

namespace Souccar.Hcpc.InputRequests.Map
{
    public class InputRequestMapProfile: Profile
    {
        public InputRequestMapProfile()
        {
            CreateMap<Souccar.Hcpc.Warehouses.InputRequest, InputRequestDto>();
            CreateMap<Souccar.Hcpc.Warehouses.InputRequest, ReadInputRequestDto>();
            CreateMap<CreateInputRequestDto, Souccar.Hcpc.Warehouses.InputRequest>();
            CreateMap<UpdateInputRequestDto, Souccar.Hcpc.Warehouses.InputRequest>();
            CreateMap<Souccar.Hcpc.Warehouses.InputRequest, UpdateInputRequestDto>();
        }
    }
}
