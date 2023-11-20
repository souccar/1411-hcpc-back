using Abp.Application.Services.Dto;
using Souccar.Hcpc.OutputRequest.Dto.OutputRequestMaterialDtos;
using System.Collections.Generic;

namespace Souccar.Hcpc.OutputRequests.Dto
{
    public class UpdateOutputRequestDto : OutputRequestBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
        public UpdateOutputRequestDto()
        {
            OutputRequestMaterials = new List<UpdateOutputRequestMaterialDto>();
        }
        public List<UpdateOutputRequestMaterialDto> OutputRequestMaterials { get; set; }
    }
}
