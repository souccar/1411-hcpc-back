using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Core.Services.Interfaces;
using Souccar.Hcpc.Materials;
using Souccar.Hcpc.Products.Dto.Products;
using Souccar.hr.Personnel.Employees.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.hr.Personnel.Employees.Services
{
    public class ChildAppService :
        AsyncSouccarAppService<Child, ChildDto, int, FullPagedRequestDto, CreateChildDto, UpdateChildDto>, IChildAppService
    {
        private readonly IChildManager _childDomainService;
        public ChildAppService(IChildManager childDomainService) : base(childDomainService)
        {
            _childDomainService = childDomainService;
        }

        public async Task<IList<ChildDto>> GetByEmployeeId(int employeeId)
        {
            var children =await _childDomainService.GetByEmployeeId(employeeId);
            var childrenDto = ObjectMapper.Map<List<ChildDto>>(children);
            return childrenDto;
        }
    }
}
