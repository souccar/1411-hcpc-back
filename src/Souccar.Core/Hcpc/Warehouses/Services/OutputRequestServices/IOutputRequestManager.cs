﻿using Souccar.Core.Services.Interfaces;
using System.Linq;

namespace Souccar.Hcpc.Warehouses.Services.OutputRequestServices
{
    public interface IOutputRequestManager : ISouccarDomainService<OutputRequest, int>
    {
        OutputRequest GetOutputRequestWithDetails(int id);
        IQueryable<OutputRequest> GetWithDetails(int planId);
    }
}
