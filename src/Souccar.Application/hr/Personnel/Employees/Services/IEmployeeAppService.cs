using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.hr.Personnel.Employees.Dto;

namespace Souccar.hr.Personnel.Employees.Services
{
    public interface IEmployeeAppService : 
        IAsyncSouccarAppService<EmployeeDto, int, PagedEmployeeRequestDto, CreateEmployeeDto, UpdateEmployeeDto>
    {

    }
}
