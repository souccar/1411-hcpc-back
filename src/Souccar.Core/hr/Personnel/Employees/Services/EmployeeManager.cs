using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;
using System.Linq;

namespace Souccar.hr.Personnel.Employees.Services
{
    public class EmployeeManager : SouccarDomainService<Employee, int>, IEmployeeManager
    {
        private readonly IRepository<Employee, int> _employeeRepository;
        public EmployeeManager(IRepository<Employee, int> employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IQueryable<Employee> GetAllWithInclude()
        {
            return _employeeRepository.GetAllIncluding(ch => ch.Children);
        }
    }
}
