using Souccar.Hcpc.Units.Dto.Units;
using Souccar.Hcpc.Units.Services.Units;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Souccar.Tests.Hcpc.Units
{
    public class UnitAppService_Test : SouccarTestBase
    {
        private readonly IUnitAppService _unitAppService;
        public UnitAppService_Test()
        {
            _unitAppService = Resolve<IUnitAppService>();
        }

        [Fact]
        public async Task CreateUnits()
        {
            //Get all units
            var pagedUnitRequest = new PagedUnitRequestDto();
            pagedUnitRequest.MaxResultCount = 100;
            pagedUnitRequest.SkipCount = 0;
            var units = await _unitAppService.GetAllAsync(pagedUnitRequest);

            UnitDto fromUnitOutput = null;
            UnitDto toUnitOutput = null;
            if (units.TotalCount > 0)
            {
                //From Unit
                fromUnitOutput = units.Items.Where(x => x.Name.ToLower().Equals("kg")).FirstOrDefault();
                //To Unit
                toUnitOutput = units.Items.Where(x => x.Name.ToLower().Equals("g")).FirstOrDefault();
            }

            if (fromUnitOutput == null)
            {
                var fromUnitInput = new CreateUnitDto();
                fromUnitInput.Name = "kg";
                fromUnitOutput = await _unitAppService.CreateAsync(fromUnitInput);
            }

            if (toUnitOutput == null)
            {
                var toUnitInput = new CreateUnitDto();
                toUnitInput.Name = "g";
                toUnitOutput = await _unitAppService.CreateAsync(toUnitInput);
            }
        }
    }
}
