using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System.Collections.Generic;
using System;
using Souccar.hr.Shared.Nationalities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.hr.Personnel.Employees
{
    public class Employee : FullAuditedAggregateRoot, IMayHaveTenant
    {
        public Employee()
        {
            Children = new List<Child>();
        }
        public int? TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public virtual IList<Child> Children { get; set; }

        #region Nationality
        public int? NationalityId { get; set; }

        [ForeignKey("NationalityId")]
        public virtual Nationality Nationality { get; set; }
        #endregion

    }
}
