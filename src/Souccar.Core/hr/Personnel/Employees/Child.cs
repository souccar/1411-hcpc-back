using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;

namespace Souccar.hr.Personnel.Employees
{
    public class Child : Entity, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        #region Employee
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        #endregion
    }
}
