using Abp.Application.Services.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Filter;
using Souccar.Core.Services;
using Souccar.hr.Personnel.Employees.Dto;
using System.Collections.Generic;

namespace Souccar.hr.Personnel.Employees.Services
{
    public interface IEmployeeAppService : 
        IAsyncSouccarAppService<EmployeeDto, int, FullPagedRequestDto, CreateEmployeeDto, UpdateEmployeeDto>
    {
       
    }
}
