using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Materials.Dto
{
    public class UpdateMaterialDto: MaterialBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
    }
}
