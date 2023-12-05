using Abp.Application.Services.Dto;
using Abp.Domain.Uow;
using Abp.Events.Bus;
using Souccar.Core.Services;
using Souccar.Core.Services.Interfaces;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.Warehouses.Events;
using Souccar.Hcpc.Warehouses.Services.OutputRequestServices;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto;
using System.Threading.Tasks;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Services
{
    public class OutputRequestAppService :
        AsyncSouccarAppService<OutputRequest, OutputRequestDto, int, PagedOutputRequestDto, CreateOutputRequestDto, UpdateOutputRequestDto>, IOutputRequestAppService
    {
        private readonly IOutputRequestManager _outputRequestManager;
        public OutputRequestAppService(IOutputRequestManager outputRequestManager) : base(outputRequestManager)
        {
            _outputRequestManager = outputRequestManager;
        }

        public override async Task<OutputRequestDto> GetAsync(EntityDto<int> input)
        {
            var outputRequestWithDetails = _outputRequestManager.GetOutputRequestWithDetails(input.Id);

            return ObjectMapper.Map<OutputRequestDto>(outputRequestWithDetails);
        }

        public override async Task<OutputRequestDto> CreateAsync(CreateOutputRequestDto input)
        {
            var ouputRequest = MapToEntity(input);
            var createdOutputRequest = await _outputRequestManager.InsertAsync(ouputRequest);

                foreach (var OutputRequestMaterial in createdOutputRequest.OutputRequestMaterials)
                {
                    EventBus.Default
                        .Trigger(new ModifyCurrentQuantityOfWarehouseMaterialData(OutputRequestMaterial.WarehouseMaterialId, OutputRequestMaterial.Quantity));
                }

            var outputRequestWithDetails = _outputRequestManager.GetOutputRequestWithDetails(createdOutputRequest.Id);

            return ObjectMapper.Map<OutputRequestDto>(outputRequestWithDetails);
            }
        }
    }
