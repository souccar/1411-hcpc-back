using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.hr.Personnel.Employees.Dto;
using System.Threading.Tasks;

namespace Souccar.hr.Personnel.Employees.Services
{
    public class EmployeeAppService :
        AsyncSouccarAppService<Employee, EmployeeDto, int, FullPagedRequestDto, CreateEmployeeDto, UpdateEmployeeDto>, IEmployeeAppService
    {
        private readonly IEmployeeManager _employeeDomainService;
        public EmployeeAppService(IEmployeeManager employeeDomainService) : base(employeeDomainService)
        {
            _employeeDomainService = employeeDomainService;
        }
    }
}
