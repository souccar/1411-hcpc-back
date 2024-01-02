using Abp.Application.Services.Dto;
using Souccar.Consts;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.WarehousesApp.Dto.OutputRequests.OutputRequestProductDtos
{
    public class UpdateOutputRequestProductDto : EntityDto<int>
    {
        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? ProductId { get; set; }
    }
}
