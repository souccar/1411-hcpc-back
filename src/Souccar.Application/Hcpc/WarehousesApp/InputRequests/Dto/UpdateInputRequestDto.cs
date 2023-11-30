using Abp.Application.Services.Dto;
using Souccar.Hcpc.WarehousesApp.InputRequests.Dto.InputRequestMaterialDtos;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.InputRequests.Dto
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
