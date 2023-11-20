using Abp.Application.Services.Dto;
using Souccar.Hcpc.OutputRequest.Dto.OutputRequestMaterialDtos;
using System.Collections.Generic;

namespace Souccar.Hcpc.OutputRequests.Dto
{
    public class OutputRequestDto : OutputRequestBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
        public OutputRequestDto()
        {
            OutputRequestMaterials = new List<OutputRequestMaterialDto>();
        }
        public List<OutputRequestMaterialDto> OutputRequestMaterials { get; set; }

    }
}
