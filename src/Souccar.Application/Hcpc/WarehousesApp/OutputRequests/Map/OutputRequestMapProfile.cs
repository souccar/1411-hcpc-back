using AutoMapper;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Map
{
    public class OutputRequestMapProfile : Profile
    {
        public OutputRequestMapProfile()
        {
            CreateMap<OutputRequest, OutputRequestDto>();
            CreateMap<OutputRequest, ReadOutputRequestDto>();
            CreateMap<CreateOutputRequestDto, OutputRequest>();
            CreateMap<UpdateOutputRequestDto, OutputRequest>();
            CreateMap<OutputRequest, UpdateOutputRequestDto>();
            CreateMap<OutputRequest, OutputRequestNameForDropdownDto>();
        }
    }
}
