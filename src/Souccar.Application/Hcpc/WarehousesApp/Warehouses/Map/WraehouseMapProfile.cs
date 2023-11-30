using AutoMapper;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.WarehousesApp.Warehouses.Dto;

namespace Souccar.Hcpc.WarehousesApp.Warehouses.Map
{
    public class WraehouseMapProfile : Profile
    {
        public WraehouseMapProfile()
        {
            CreateMap<Warehouse, WarehouseDto>();
            CreateMap<Warehouse, ReadWarehouseDto>();
            CreateMap<CreateWarehouseDto, Warehouse>();
            CreateMap<UpdateWarehouseDto, Warehouse>();
            CreateMap<Warehouse, UpdateWarehouseDto>();
        }
    }
}
