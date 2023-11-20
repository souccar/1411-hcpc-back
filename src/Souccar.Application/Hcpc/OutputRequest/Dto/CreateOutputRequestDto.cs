using Souccar.Hcpc.OutputRequest.Dto.OutputRequestMaterialDtos;
using System.Collections.Generic;

namespace Souccar.Hcpc.OutputRequests.Dto
{
    public class CreateOutputRequestDto: OutputRequestBaseDto
    {
        public CreateOutputRequestDto()
        {
            OutputRequestMaterials = new List<CreateOutputRequestMaterialDto>();
        }
        public List<CreateOutputRequestMaterialDto> OutputRequestMaterials { get; set; }
    }
}
