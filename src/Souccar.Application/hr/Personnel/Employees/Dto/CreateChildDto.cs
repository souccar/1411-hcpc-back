using Abp.Application.Services;
using System;

namespace Souccar.hr.Personnel.Employees.Dto
{
    public class CreateChildDto
    {
        
        public int? EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
    }
}
