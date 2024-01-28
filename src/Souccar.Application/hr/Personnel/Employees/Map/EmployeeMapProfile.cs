using AutoMapper;
using Souccar.hr.Personnel.Employees.Dto;

namespace Souccar.hr.Personnel.Employees.Map
{
    public class EmployeeMapProfile: Profile
    {
        public EmployeeMapProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<Employee, UpdateEmployeeDto>();


        }
    }
}
