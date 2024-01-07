using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Extensions;
using Souccar.Core.Services;
using Souccar.hr.Personnel.Employees.Dto;
using System.Linq;

namespace Souccar.hr.Personnel.Employees.Services
{
    public class EmployeeAppService : 
        AsyncSouccarAppService<Employee, EmployeeDto, int, PagedEmployeeRequestDto, CreateEmployeeDto, UpdateEmployeeDto>, IEmployeeAppService
    {
        private readonly IEmployeeManager _employeeDomainService;
        public EmployeeAppService(IEmployeeManager employeeDomainService): base(employeeDomainService)
        {
            _employeeDomainService = employeeDomainService;
        }

        protected override IQueryable<Employee> CreateFilteredQuery(PagedEmployeeRequestDto input)
        {
            var list = _employeeDomainService.GetAll();
            if (!input.Keyword.IsNullOrWhiteSpace())
            {
                list = list.Where(x => x.FirstName.Contains(input.Keyword) || x.LastName.Contains(input.Keyword));
            }
            return list;
        }
    }
}
