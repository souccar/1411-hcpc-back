using Souccar.Core.Services.Interfaces;
using Souccar.Hcpc.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.hr.Personnel.Employees.Services
{
    public interface IChildManager :ISouccarDomainService<Child, int>
    {
        Task<IList<Child>> GetByEmployeeId(int employeeId);


    }
}
