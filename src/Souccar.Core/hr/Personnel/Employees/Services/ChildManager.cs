using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.hr.Personnel.Employees.Services
{
    public class ChildManager : SouccarDomainService<Child, int>, IChildManager
    {
        private readonly IRepository<Child, int> _childRepository;
        private readonly IRepository<Employee, int> _employeeRepository;

        public ChildManager(IRepository<Child, int> childRepository) : base(childRepository)
        {
            _childRepository = childRepository;
        }

        public async Task<IList<Child>> GetByEmployeeId(int employeeId)
        {
            var children = await _childRepository.GetAllListAsync(x => x.EmployeeId == employeeId);
            return  children;
        }

        
    }
}
