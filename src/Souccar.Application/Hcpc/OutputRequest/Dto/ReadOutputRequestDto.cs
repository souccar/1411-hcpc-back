using Abp.Application.Services.Dto;
using Souccar.Hcpc.OutputRequest.Dto.OutputRequestMaterialDtos;
using System.Collections.Generic;

namespace Souccar.Hcpc.OutputRequests.Dto
{
    public class ReadOutputRequestDto : OutputRequestBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
        public ReadOutputRequestDto()
        {
            OutputRequestMaterials = new List<ReadOutputRequestMaterialDto>();
        }
        public List<ReadOutputRequestMaterialDto> OutputRequestMaterials { get; set; }

    }
}
