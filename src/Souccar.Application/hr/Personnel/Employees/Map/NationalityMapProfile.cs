using AutoMapper;
using Souccar.hr.Shared.Nationalities;
using Souccar.hr.Shared.Nationalities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souccar.hr.Personnel.Employees.Map
{
    public class NationalityMapProfile: Profile
    {
        public NationalityMapProfile()
        {
            CreateMap<Nationality, NationalityDto>();
            CreateMap<Nationality, ReadNationalityDto>();
        }
    }
}
