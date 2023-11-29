using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Materials.Dto.MaterialSuppliersDtos
{
    public class UpdateMaterialSuppliersDto :  IEntityDto<int>
    {
        public int SupplierId { get; set; }
        public int Id { get; set; }
        public int MaterialId { get; set; }
    }
}
