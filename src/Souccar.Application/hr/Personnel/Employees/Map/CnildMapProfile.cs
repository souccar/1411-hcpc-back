using AutoMapper;
using Souccar.hr.Personnel.Employees;
using Souccar.hr.Personnel.Employees.Dto;

namespace Souccar.hr.Personnel.Childs.Map
{
    public class CnildMapProfile: Profile
    {
        public CnildMapProfile()
        {
            CreateMap<Child, ChildDto>();
            CreateMap<CreateChildDto, Child>();
            CreateMap<UpdateChildDto, Child>();
        }
    }
}
