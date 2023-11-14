using System;
using System.Collections.Generic;

namespace Souccar.hr.Personnel.Employees.Dto
{
    public class CreateEmployeeDto
    {
        public CreateEmployeeDto()
        {
            Children = new List<CreateChildDto>();
        }
        public int? TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public virtual IList<CreateChildDto> Children { get; set; }
    }
}
