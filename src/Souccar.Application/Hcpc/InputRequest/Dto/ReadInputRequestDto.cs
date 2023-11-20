using Abp.Application.Services.Dto;
using Souccar.Hcpc.InputRequest.Dto.InputRequestMaterialDto;
using System.Collections.Generic;

namespace Souccar.Hcpc.InputRequests.Dto
{
    public class ReadInputRequestDto : InputRequestBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
        public ReadInputRequestDto()
        {
            InputRequestMaterials = new List<ReadInputRequestMaterialDto>();
        }
        public List<ReadInputRequestMaterialDto> InputRequestMaterials { get; set; }

    }
}
