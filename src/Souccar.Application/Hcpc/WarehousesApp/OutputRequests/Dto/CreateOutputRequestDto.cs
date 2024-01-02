using Souccar.Consts;
using Souccar.Hcpc.WarehousesApp.Dto.OutputRequests.OutputRequestProductDtos;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestMaterialDtos;
using Souccar.Validation.List;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Dto
{
    public class CreateOutputRequestDto
    {
        public CreateOutputRequestDto()
        {
            OutputRequestMaterials = new List<CreateOutputRequestMaterialDto>();
            OutputRequestProducts = new List<CreateOutputRequestProductDto>();
        }

        [Required(ErrorMessage = SouccarAppConstant.Required, AllowEmptyStrings = false), MaxLength(SouccarAppConstant.SimpleStringMaxLength)]
        public string Title { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? PlanId { get; set; }

        [NotEmptyList(ErrorMessage = SouccarAppConstant.EmptyList)]
        public List<CreateOutputRequestMaterialDto> OutputRequestMaterials { get; set; }

        [NotEmptyList(ErrorMessage = SouccarAppConstant.EmptyList)]
        public List<CreateOutputRequestProductDto> OutputRequestProducts { get; set; }
    }
}
