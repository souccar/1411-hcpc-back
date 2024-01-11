using Abp.Application.Services.Dto;
using Souccar.Core.CustomAttributes;
using Souccar.hr.Shared.Nationalities.Dto;
using System;

namespace Souccar.hr.Personnel.Employees.Dto
{
    public class ReadEmployeeDto: EntityDto<int>
    {
        [ReadUserInterface(Searchable = true)]
        public string FirstName { get; set; }

        [ReadUserInterface(Searchable = true)]
        public string LastName { get; set; }

        [ReadUserInterface(IsHidden = true)]
        public int Age { get; set; }

        [ReadUserInterface(Formate ="dd MM YYYY")]
        public DateTime? DateOfBirth { get; set; }
        public int NationalityId { get; set; }
        public NationalityDto Nationality { get; set; }
    }
}
