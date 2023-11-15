using AutoMapper;
using Souccar.Hcpc.OutputRequests.Dto;
using Souccar.Hcpc.Warehouses;

namespace Souccar.Hcpc.OutputRequests.Map
{
    public class OutputRequestMapProfile: Profile
    {
        public OutputRequestMapProfile()
        {
            CreateMap<OutputRequest, OutputRequestDto>();
            CreateMap<OutputRequest, ReadOutputRequestDto>();
            CreateMap<CreateOutputRequestDto, OutputRequest>();
            CreateMap<UpdateOutputRequestDto, OutputRequest>();
            CreateMap<OutputRequest, UpdateOutputRequestDto>();
        }
    }
}
