using AutoMapper;
using Souccar.Hcpc.Materials.Dto.MaterialSuppliersDtos;

namespace Souccar.Hcpc.Materials.Map
{
    public class MaterialSupplierMapProfile : Profile
    {
        public MaterialSupplierMapProfile()
        {
            CreateMap<MaterialSuppliers, MaterialSuppliersDto>();
            CreateMap<MaterialSuppliers, ReadMaterialSuppliersDto>();
            CreateMap<CreateMaterialSuppliersDto, MaterialSuppliers>();
            CreateMap<UpdateMaterialSuppliersDto, MaterialSuppliers>();
            CreateMap<MaterialSuppliers, UpdateMaterialSuppliersDto>();
        }
    }
}
