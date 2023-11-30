using Abp.Application.Services.Dto;
using Souccar.Hcpc.WarehousesApp.InputRequests.Dto.InputRequestMaterialDtos;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.InputRequests.Dto
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
