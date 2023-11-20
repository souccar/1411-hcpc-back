using Abp.Application.Services.Dto;
using Souccar.Hcpc.InputRequest.Dto.InputRequestMaterialDto;
using System.Collections.Generic;

namespace Souccar.Hcpc.InputRequests.Dto
{
    public class InputRequestDto : InputRequestBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
        public InputRequestDto()
        {
            InputRequestMaterials = new List<InputRequestMaterialDto>();
        }
        public List<InputRequestMaterialDto> InputRequestMaterials { get; set; }

    }
}
