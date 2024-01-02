using Souccar.Consts;
using Souccar.Hcpc.Materials.Dto.MaterialSuppliersDtos;
using Souccar.Validation.List;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.Materials.Dto
{
    public class CreateMaterialDto
    {
        public CreateMaterialDto()
        {
            Suppliers = new List<CreateMaterialSuppliersDto>();
        }

        [Required(ErrorMessage = SouccarAppConstant.Required, AllowEmptyStrings = false), MaxLength(SouccarAppConstant.SimpleStringMaxLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required, AllowEmptyStrings = false), MaxLength(SouccarAppConstant.SimpleStringMaxLength)]
        public string Code { get; set; }

        [MaxLength(SouccarAppConstant.MultiLinesStringMaxLength)]
        public string Description { get; set; }


        [NotEmptyList(ErrorMessage = SouccarAppConstant.EmptyList)]
        public IList<CreateMaterialSuppliersDto> Suppliers { get; set; }
    }
}
