using Abp.Application.Services.Dto;
using Souccar.hr.Shared.Nationalities;
using Souccar.hr.Shared.Nationalities.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.hr.Personnel.Employees.Dto
{
    public class EmployeeDto : EntityDto<int>
    {
        public EmployeeDto()
        {
            Children = new List<ChildDto>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public IList<ChildDto> Children { get; set; }

        #region Nationality
        public int NationalityId { get; set; }

        public NationalityDto Nationality { get; set; }
        #endregion
    }
}
