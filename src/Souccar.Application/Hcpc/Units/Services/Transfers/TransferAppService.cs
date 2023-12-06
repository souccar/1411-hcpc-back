using Abp.UI;
using Newtonsoft.Json.Linq;
using Souccar.Core.Services;
using Souccar.Hcpc.Units;
using Souccar.Hcpc.Units.Dto.Transfers;
using Souccar.Hcpc.Units.Dto.Units;
using Souccar.Hcpc.Units.Services;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Transfers.Services.Transfers
{
    public class TransferAppService :
        AsyncSouccarAppService<Transfer, TransferDto, int, PagedTransferRequestDto, CreateTransferDto, UpdateTransferDto>, ITransferAppService
    {
        private readonly ITransferManager _transferManager;

        public TransferAppService(ITransferManager transferManager) : base(transferManager)
        {
            _transferManager = transferManager;
            
        }

        public async Task<ConvertToOutputDto> ConvertTo(ConvertToInputDto input)
        {
            var value = await _transferManager.ConvertTo(input.FromId, input.ToId, input.Value);
            return new ConvertToOutputDto(value);
        }


        //public TransferToGreaterUnitOutputDto ConvertToGreaterUnit(TransferToGreaterUnitInputDto input)
        //{
        //    var tuple = _transferManager.ConvertToGreaterUnit(Tuple.Create<int, double>(input.UnitId.Value, input.Value));
        //    return new TransferToGreaterUnitOutputDto(tuple.Item2, tuple.Item1, null);
        //}
    }
}
