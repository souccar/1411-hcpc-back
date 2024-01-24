using AutoMapper;
using Souccar.hr.Shared.Nationalities.Dto;

namespace Souccar.hr.Shared.Nationalities.Map
{
    public class NationalityMapProfile: Profile
    {
        public NationalityMapProfile()
        {
            CreateMap<Nationality, NationalityDto>();
        }
    }
}
