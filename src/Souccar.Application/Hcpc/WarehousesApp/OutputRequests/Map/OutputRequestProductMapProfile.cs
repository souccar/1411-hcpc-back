using AutoMapper;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.WarehousesApp.Dto.OutputRequests.OutputRequestProductDtos;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestProductDtos;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestProducts;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Map
{
    public class OutputRequestProductMapProfile : Profile
    {
        public OutputRequestProductMapProfile()
        {
            CreateMap<OutputRequestProduct, OutputRequestProductDto>()
                .ForMember(x => x.CanProduce, m => m.Ignore());
            CreateMap<CreateOutputRequestProductDto, OutputRequestProduct>();
            CreateMap<OutputRequestProduct, CreateOutputRequestProductDto>();
            CreateMap<UpdateOutputRequestProductDto, OutputRequestProduct>();
            CreateMap<OutputRequestProduct, UpdateOutputRequestProductDto>();
            CreateMap<ReadOutputRequesProductDto, OutputRequestProduct>();
            CreateMap<OutputRequestProduct, ReadOutputRequesProductDto>();
        }
    }
}
