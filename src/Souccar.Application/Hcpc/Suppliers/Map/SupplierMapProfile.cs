using AutoMapper;
using Souccar.Hcpc.Suppliers.Dto;

namespace Souccar.Hcpc.Suppliers.Map
{
    public class SupplierMapProfile: Profile
    {
        public SupplierMapProfile()
        {
            CreateMap<Supplier, SupplierDto>();
            CreateMap<Supplier, ReadSupplierDto>();
            CreateMap<CreateSupplierDto, Supplier>();
            CreateMap<UpdateSupplierDto, Supplier>();
            CreateMap<Supplier, UpdateSupplierDto>();
            CreateMap<Supplier, SupplierNameForDropdownDto>();
        }
    }
}
