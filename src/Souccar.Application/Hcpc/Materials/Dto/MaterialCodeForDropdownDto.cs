using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Materials.Dto
{
    public class MaterialCodeForDropdownDto : EntityDto<int>
    {
        public MaterialCodeForDropdownDto(int id, string code)
        {
            Id = id;
            Code = code;
        }

        public string Code { get; set; }
    }
}
