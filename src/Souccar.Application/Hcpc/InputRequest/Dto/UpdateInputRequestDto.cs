using Abp.Application.Services.Dto;
using Souccar.Hcpc.InputRequest.Dto.InputRequestMaterialDto;
using System.Collections.Generic;

namespace Souccar.Hcpc.InputRequests.Dto
{
    public class UpdateInputRequestDto : InputRequestBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
        public UpdateInputRequestDto()
        {
            InputRequestMaterials = new List<UpdateInputRequestMaterialDto>();
        }
        public List<UpdateInputRequestMaterialDto> InputRequestMaterials { get; set; }
    }
}
