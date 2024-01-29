using AutoMapper;
using Souccar.hr.Personnel.Employees;
using Souccar.hr.Personnel.Employees.Dto;

namespace Souccar.hr.Personnel.Childs.Map
{
    public class ChildMapProfile: Profile
    {
        public ChildMapProfile()
        {
            CreateMap<Child, ChildDto>();
            CreateMap<CreateChildDto, Child>();
            CreateMap<UpdateChildDto, Child>();
            CreateMap<Child, UpdateChildDto>();
        }
    }
}
