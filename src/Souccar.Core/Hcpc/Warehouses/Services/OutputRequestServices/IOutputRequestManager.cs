﻿using Souccar.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Warehouses.Services.OutputRequestServices
{
    public interface IOutputRequestManager : ISouccarDomainService<OutputRequest, int>
    {
        OutputRequest GetOutputRequestWithDetails(int id);
        IQueryable<OutputRequest> GetWithDetails(int planId);
        IQueryable<OutputRequest> GetPlanOutputRequests(int planId);
        Task<OutputRequest> ChangeStatus(OutputRequestStatus status, int id);
        public List<OutputRequest> GetAllIncluding();
        IQueryable<OutputRequest> CreateFilteredQuery(string including, long? currentUserId);
    }
}
