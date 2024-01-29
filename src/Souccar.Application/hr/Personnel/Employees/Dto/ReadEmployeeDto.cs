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
        public int Age {     
            get
            {
                var now = DateTime.Today;
                var age = now.Year - DateOfBirth.Value.Year;
                if (now < DateOfBirth.Value.AddYears(age))
                    age--;
                return age;
            } }

        [ReadUserInterface(Formate ="dd MM YYYY")]
        public DateTime? DateOfBirth { get; set; }
        public int NationalityId { get; set; }
        public NationalityDto Nationality { get; set; }
    }
}
