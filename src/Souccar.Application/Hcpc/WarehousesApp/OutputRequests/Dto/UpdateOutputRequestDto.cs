using Abp.Application.Services.Dto;
using Souccar.Consts;
using Souccar.Hcpc.WarehousesApp.Dto.OutputRequests.OutputRequestProductDtos;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestMaterialDtos;
using Souccar.Validation.List;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Dto
{
    public class UpdateOutputRequestDto : EntityDto<int>
    {
       
        public UpdateOutputRequestDto()
        {
            OutputRequestMaterials = new List<UpdateOutputRequestMaterialDto>();
            OutputRequestProducts = new List<UpdateOutputRequestProductDto>();
        }

        [Required(ErrorMessage = SouccarAppConstant.Required ,AllowEmptyStrings = false) ,MaxLength(SouccarAppConstant.SimpleStringMaxLength)]
        public string Title { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? PlanId { get; set; }

        [NotEmptyList(ErrorMessage = SouccarAppConstant.EmptyList)]
        public List<UpdateOutputRequestMaterialDto> OutputRequestMaterials { get; set; }

        [NotEmptyList(ErrorMessage = SouccarAppConstant.EmptyList)]
        public List<UpdateOutputRequestProductDto> OutputRequestProducts { get; set; }

    }
}
