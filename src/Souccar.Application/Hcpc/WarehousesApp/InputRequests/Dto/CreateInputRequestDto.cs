using Souccar.Hcpc.WarehousesApp.InputRequests.Dto.InputRequestMaterialDtos;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.InputRequests.Dto
{
    public class CreateInputRequestDto : InputRequestBaseDto
    {
        public CreateInputRequestDto()
        {
            InputRequestMaterials = new List<CreateInputRequestMaterialDto>();
        }
        public List<CreateInputRequestMaterialDto> InputRequestMaterials { get; set; }
    }
}
