using Souccar.Hcpc.Transfers.Services.Transfers;
using Souccar.Hcpc.Units.Dto.Transfers;
using System.Threading.Tasks;
using Xunit;

namespace Souccar.Tests.Hcpc.Units
{
    public class TransferAppService_Test : SouccarTestBase
    {
        private readonly ITransferAppService _transferAppService;
        public TransferAppService_Test()
        {
            _transferAppService = Resolve<ITransferAppService>();
        }

        [Fact]
        public async Task ConvertTo()
        {
            var input = new ConvertToInputDto()
            {
                FromId = 1,
                ToId = 2,
                Value = 100
            };

            await _transferAppService.ConvertTo(input); 
        }
    }
}
