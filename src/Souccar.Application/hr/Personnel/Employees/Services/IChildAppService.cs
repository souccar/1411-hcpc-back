using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Hcpc.Products.Dto.Products;
using Souccar.hr.Personnel.Employees.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.hr.Personnel.Employees.Services
{
    public interface IChildAppService:
        IAsyncSouccarAppService<ChildDto,int, FullPagedRequestDto, CreateChildDto, UpdateChildDto>
    {
        Task<IList<ChildDto>> GetByEmployeeId(int employeeId);
    }
}
