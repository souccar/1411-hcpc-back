using Abp.Application.Services.Dto;
using Abp.Domain.Uow;
using Abp.Events.Bus;
using Souccar.Authorization.Users;
using Souccar.Core.Services;
using Souccar.Core.Services.Interfaces;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.Warehouses.Events;
using Souccar.Hcpc.Warehouses.Services.OutputRequestServices;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto;
using Souccar.Notification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Services
{
    public class OutputRequestAppService :
        AsyncSouccarAppService<OutputRequest, OutputRequestDto, int, PagedOutputRequestDto, CreateOutputRequestDto, UpdateOutputRequestDto>, IOutputRequestAppService
    {
        private readonly IOutputRequestManager _outputRequestManager;
        private readonly IAppNotifier _notifier;
        private readonly UserManager _userManager;
        public OutputRequestAppService(IOutputRequestManager outputRequestManager, IAppNotifier notifier, UserManager userManager) : base(outputRequestManager)
        {
            _outputRequestManager = outputRequestManager;
            _notifier = notifier;
            _userManager = userManager;
        }

        public override async Task<OutputRequestDto> GetAsync(EntityDto<int> input)
        {
            var outputRequestWithDetails = _outputRequestManager.GetOutputRequestWithDetails(input.Id);

            return ObjectMapper.Map<OutputRequestDto>(outputRequestWithDetails);
        }

        public override async Task<OutputRequestDto> CreateAsync(CreateOutputRequestDto input)
        {
            var admin = _userManager.GetUserById(1);
            var ouputRequest = MapToEntity(input);
            var createdOutputRequest = await _outputRequestManager.InsertAsync(ouputRequest);

            foreach (var OutputRequestMaterial in createdOutputRequest.OutputRequestMaterials)
            {
                EventBus.Default
                    .Trigger(new ModifyCurrentQuantityOfWarehouseMaterialData(OutputRequestMaterial.WarehouseMaterialId, OutputRequestMaterial.Quantity));
            }

            await _notifier.SendCreateOutputRequst(admin, input.Title);

            var outputRequestWithDetails = _outputRequestManager.GetOutputRequestWithDetails(createdOutputRequest.Id);

            return ObjectMapper.Map<OutputRequestDto>(outputRequestWithDetails);
        }

        public IList<OutputRequestDto> GetPlanOutputRequests(int planId)
        {
           
            return ObjectMapper.Map<List<OutputRequestDto>>(_outputRequestManager.GetPlanOutputRequests(planId)); ;
        }

    }
}
