using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Abp.Threading;
using Abp.UI;
using AutoMapper.Internal.Mappers;
using Souccar.Core.Services.Implements;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Units.Services
{
    public class TransferManager : SouccarDomainService<Transfer, int>, ITransferManager
    {
        private readonly IRepository<Transfer, int> _transferRepository;
        
        public TransferManager(IRepository<Transfer, int> transferRepository) : base(transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public async Task<double> ConvertTo(int? fromId, int? toId, double value)
        {
            if (fromId == toId)
            {
                return value;
            }

            if (fromId == null || toId == null)
                throw new UserFriendlyException("Unit is null");

            Transfer transfer;
            transfer = await _transferRepository.FirstOrDefaultAsync(x => x.From.Id == fromId && x.To.Id == toId);
            if(transfer != null)
            {
                return value * transfer.Value;
            }

            transfer = await _transferRepository.FirstOrDefaultAsync(x => x.To.Id == fromId && x.From.Id == toId);
            if (transfer != null)
            {
                return value / transfer.Value;
            }

            return 0;
            
        }

        public IDictionary<string, object> ConvertToGreaterUnit(int unitId, double value)
        {
            var result = new Dictionary<string, object>() {
                {"UnitId", unitId},
                {"Value", value},
            };

            var transfer = GetByDestinationUnitId(unitId);
            if (transfer is null || value <= transfer.Value)
            {
                return result;
            }

            var transferredValue = value > 0 ? value / transfer.Value : 0;
            result["UnitId"] = transfer.FromId;
            result["Value"] = transferredValue;
            return result;
        }

        public Transfer GetBySourceUnitId(int? unitId)
        {
            var transfer =  _transferRepository.FirstOrDefault(x => x.FromId == unitId);
             _transferRepository.EnsurePropertyLoaded(transfer, x => x.From);
             _transferRepository.EnsurePropertyLoaded(transfer, x => x.To);
            return transfer;
        }

        public Transfer GetByDestinationUnitId(int? unitId)
        {
            var transfer =  _transferRepository.FirstOrDefault(x => x.ToId == unitId);
            _transferRepository.EnsurePropertyLoaded(transfer, x => x.From);
            _transferRepository.EnsurePropertyLoaded(transfer, x => x.To);
            return transfer;
        }
    }
}
