using Abp.UI;
using Newtonsoft.Json.Linq;
using Souccar.Core.Services;
using Souccar.Hcpc.Units;
using Souccar.Hcpc.Units.Dto.Transfers;
using Souccar.Hcpc.Units.Services;
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


        public async Task<TransferToGreaterUnitOutputDto> ConvertToGreaterUnit(TransferToGreaterUnitInputDto input)
        {
            if (input.Value >= 1000)
            {
                var transfer = _transferManager.GetAll().FirstOrDefault(x => x.ToId == input.UnitId);
                if(transfer is null) { 
                 throw new UserFriendlyException("TransferForThisOperationIsNotFound");
                }
                else
                {
                    var convertToOutputDto = await ConvertTo(new ConvertToInputDto() { FromId = (int)transfer.ToId, ToId = (int)transfer.FromId, Value = input.Value });
                    var value = new TransferToGreaterUnitOutputDto() { Value = convertToOutputDto.Value, UnitId = (int)transfer.FromId };
                    return value;
                }
              
            }
            else
            { 
                // if value is less than 1000 return same value
                var value = new TransferToGreaterUnitOutputDto() { Value = input.Value, UnitId = input.UnitId};
                return value;
            }
          
        }
    }
}
