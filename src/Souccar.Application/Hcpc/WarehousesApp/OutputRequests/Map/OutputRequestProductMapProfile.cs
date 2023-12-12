using AutoMapper;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.WarehousesApp.Dto.OutputRequests.OutputRequestProductDtos;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestProductDtos;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Map
{
    public class OutputRequestProductMapProfile : Profile
    {
        public OutputRequestProductMapProfile()
        {
            CreateMap<CreateOutputRequestProductDto, OutputRequestProduct>();
            CreateMap<OutputRequestProduct, CreateOutputRequestProductDto>();
            CreateMap<UpdateOutputRequestProductDto, OutputRequestProduct>();
            CreateMap<OutputRequestProduct, UpdateOutputRequestProductDto>();
            CreateMap<ReadOutputRequesProductDto, OutputRequestProduct>();
            CreateMap<OutputRequestProduct, ReadOutputRequesProductDto>();
        }
    }
}
