﻿using Souccar.Core.Services.Interfaces;
using System.Linq;

namespace Souccar.hr.Personnel.Employees.Services
{
    public interface IEmployeeManager : ISouccarDomainService<Employee, int>
    {
        IQueryable<Employee> GetAllWithInclude();
    }
}
