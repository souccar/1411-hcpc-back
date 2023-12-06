using Abp.Application.Services.Dto;
using System;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Dto
{
    public class OutputRequestForWarehouseMaterialDto : IEntityDto<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string OutputDate { get; set; }
        public double Quantity { get; set; }
    }
}
