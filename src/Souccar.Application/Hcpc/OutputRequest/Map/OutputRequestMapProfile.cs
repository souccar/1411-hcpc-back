using AutoMapper;
using Souccar.Hcpc.OutputRequests.Dto;

namespace Souccar.Hcpc.OutputRequests.Map
{
    public class OutputRequestMapProfile: Profile
    {
        public OutputRequestMapProfile()
        {
            CreateMap<Souccar.Hcpc.Warehouses.OutputRequest, OutputRequestDto>();
            CreateMap<Souccar.Hcpc.Warehouses.OutputRequest, ReadOutputRequestDto>();
            CreateMap<CreateOutputRequestDto, Souccar.Hcpc.Warehouses.OutputRequest>();
            CreateMap<UpdateOutputRequestDto, Souccar.Hcpc.Warehouses.OutputRequest>();
            CreateMap<Souccar.Hcpc.Warehouses.OutputRequest, UpdateOutputRequestDto>();
        }
    }
}
