using Souccar.Core.Services;
using Souccar.hr.Personnel.Employees.Dto;


namespace Souccar.hr.Personnel.Employees.Services
{
    public class EmployeeAppService :
        AsyncSouccarAppService<Employee, EmployeeDto, int, PagedEmployeeRequestDto, CreateEmployeeDto, UpdateEmployeeDto>, IEmployeeAppService
    {
        private readonly IEmployeeManager _employeeDomainService;
        public EmployeeAppService(IEmployeeManager employeeDomainService) : base(employeeDomainService)
        {
            _employeeDomainService = employeeDomainService;
        }
    }
}
