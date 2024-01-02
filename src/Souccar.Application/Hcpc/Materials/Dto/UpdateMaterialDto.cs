using Abp.Application.Services.Dto;
using Souccar.Consts;
using Souccar.Hcpc.Materials.Dto.MaterialSuppliersDtos;
using Souccar.Validation.List;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.Materials.Dto
{
    public class UpdateMaterialDto: EntityDto<int>
    {
        public UpdateMaterialDto()
        {
            Suppliers = new List<UpdateMaterialSuppliersDto>();
        }
        [Required(ErrorMessage = SouccarAppConstant.Required, AllowEmptyStrings = false), MaxLength(SouccarAppConstant.SimpleStringMaxLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required, AllowEmptyStrings = false), MaxLength(SouccarAppConstant.SimpleStringMaxLength)]
        public string Code { get; set; }

        [MaxLength(SouccarAppConstant.MultiLinesStringMaxLength)]
        public string Description { get; set; }


        [NotEmptyList(ErrorMessage = SouccarAppConstant.EmptyList)]
        public IList<UpdateMaterialSuppliersDto> Suppliers { get; set; }
    }
}
