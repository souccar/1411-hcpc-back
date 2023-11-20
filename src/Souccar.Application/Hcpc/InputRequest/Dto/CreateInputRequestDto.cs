using Souccar.Hcpc.InputRequest.Dto.InputRequestMaterialDto;
using System.Collections.Generic;

namespace Souccar.Hcpc.InputRequests.Dto
{
    public class CreateInputRequestDto: InputRequestBaseDto
    {
        public CreateInputRequestDto()
        {
            InputRequestMaterials = new List<CreateInputRequestMaterialDto>();
        }
        public List<CreateInputRequestMaterialDto> InputRequestMaterials { get; set; }
    }
}
