using Abp.Domain.Services;
using Souccar.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Units.Services
{
    public interface ITransferManager: ISouccarDomainService<Transfer, int>
    {
        Task<double> ConvertTo(int? fromId, int? toId, double value);
        Transfer GetBySourceUnitId(int? unitId);
        Transfer GetByDestinationUnitId(int? unitId);
        IDictionary<string, object> ConvertToGreaterUnit(int id, double value);
    }
}
