using Abp.Application.Services.Dto;
using System;

namespace Souccar.hr.Personnel.Employees.Dto
{
    public class ChildDto : EntityDto<int>
    {
        public int? TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}