using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;

namespace Souccar.hr.Personnel.Employees.Dto
{
    public class UpdateEmployeeDto: EntityDto<int>
    {
        public UpdateEmployeeDto()
        {
            Children = new List<UpdateChildDto>();
        }
        public int? TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public virtual IList<UpdateChildDto> Children { get; set; }
    }
}
