using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;

namespace Souccar.hr.Personnel.Employees.Dto
{
    public class UpdateEmployeeDto: EntityDto<int>
    {
   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
   
    }
}
