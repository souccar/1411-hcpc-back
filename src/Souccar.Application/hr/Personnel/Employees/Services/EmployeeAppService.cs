using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.hr.Personnel.Employees.Dto;
using System.Linq;

namespace Souccar.hr.Personnel.Employees.Services
{
    public class EmployeeAppService : 
        AsyncSouccarAppService<Employee, EmployeeDto, int, PagedEmployeeRequestDto, CreateEmployeeDto, UpdateEmployeeDto, EmployeeDto, EntityDto<int>>, IEmployeeAppService
    {
        private readonly IEmployeeManager _employeeDomainService;
        public EmployeeAppService(IEmployeeManager employeeDomainService): base(employeeDomainService)
        {
            _employeeDomainService = employeeDomainService;
        }

        protected override IQueryable<Employee> CreateFilteredQuery(PagedEmployeeRequestDto input)
        {
            return _employeeDomainService.GetAllWithInclude();
        }
    }
}
