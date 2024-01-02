using Souccar.Consts;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.WarehousesApp.Dto.OutputRequests.OutputRequestProductDtos
{
    public class CreateOutputRequestProductDto
    {
        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? ProductId { get; set; }
    }
}
