using Abp.Application.Services.Dto;
using Abp.Events.Bus;
using Abp.UI;
using Souccar.Authorization.Users;
using Souccar.Core.Services;
using Souccar.Core.Services.Interfaces;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionDtos;
using Souccar.Hcpc.Units.Services;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.Warehouses.Events;
using Souccar.Hcpc.Warehouses.Services.OutputRequestServices;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto;
using Souccar.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Services
{
    public class OutputRequestAppService :
        AsyncSouccarAppService<OutputRequest, OutputRequestDto, int, PagedOutputRequestDto, CreateOutputRequestDto, UpdateOutputRequestDto>, IOutputRequestAppService
    {
        private readonly IOutputRequestManager _outputRequestManager;
        private readonly ITransferManager _transferManager;
        private readonly IAppNotifier _notifier;
        private readonly UserManager _userManager;
        public OutputRequestAppService(IOutputRequestManager outputRequestManager, IAppNotifier notifier, UserManager userManager, ITransferManager transferManager) : base(outputRequestManager)
        {
            _outputRequestManager = outputRequestManager;
            _notifier = notifier;
            _userManager = userManager;
            _transferManager = transferManager;
        }

        public override Task<UpdateOutputRequestDto> GetForEditAsync(EntityDto<int> input)
        {
            return base.GetForEditAsync(input);
        }

        public async override Task<OutputRequestDto> GetAsync(EntityDto<int> input)
        {
            var outputRequestWithDetails = await Task.FromResult(_outputRequestManager.GetOutputRequestWithDetails(input.Id));
            var dto = ObjectMapper.Map<OutputRequestDto>(outputRequestWithDetails);

            ////////////
            foreach (var requestProduct in dto.OutputRequestProducts)
            {
                var numberOfProducts = new List<int>();
                var formulas = requestProduct.Product.Formulas;
                foreach (var requestMaterial in dto.OutputRequestMaterials)
                {
                    var formulla = formulas.FirstOrDefault(x => x.MaterialId == requestMaterial.WarehouseMaterial.MaterialId);
                    if (formulla != null)
                    {
                        var quantity = await _transferManager.ConvertTo(requestMaterial.UnitId, formulla.UnitId, requestMaterial.Quantity);
                        var numberOfProduce = (int)(quantity / formulla.Quantity);
                        numberOfProducts.Add(numberOfProduce);
                    }
                    //else
                    //{
                    //    numberOfProducts.Add(0);
                    //}
                }
                requestProduct.CanProduce = numberOfProducts.Min() / (dto.OutputRequestMaterials.Count);
            }
            ////////////

            return dto;
        }

        public override async Task<OutputRequestDto> CreateAsync(CreateOutputRequestDto input)
        {
            var admin = _userManager.GetUserById(1);
            var ouputRequest = MapToEntity(input);
            var createdOutputRequest = await _outputRequestManager.InsertAsync(ouputRequest);            

            await _notifier.SendCreateOutputRequst(admin, input.Title);

            var outputRequestWithDetails = _outputRequestManager.GetOutputRequestWithDetails(createdOutputRequest.Id);

            return ObjectMapper.Map<OutputRequestDto>(outputRequestWithDetails);
        }

        public override async Task<PagedResultDto<OutputRequestDto>> GetAllAsync(PagedOutputRequestDto input)
        {
            PagedResultDto<OutputRequestDto> result = new PagedResultDto<OutputRequestDto>();

            List<OutputRequestDto> dtos = new List<OutputRequestDto>();

            var allOutputRequests = _outputRequestManager.GetAllIncluding();

            result.TotalCount = allOutputRequests.Count;

            foreach (var allOutputRequest in allOutputRequests)
            {
                var itemDto = ObjectMapper.Map<OutputRequestDto>(allOutputRequest);
                dtos.Add(itemDto);
            }

            result.Items = dtos;
            return result;
        }
        public IList<OutputRequestDto> GetPlanOutputRequests(int planId)
        {          
            return ObjectMapper.Map<List<OutputRequestDto>>(_outputRequestManager.GetPlanOutputRequests(planId));
        }        

        public async Task<List<OutputRequestWithDetailDto>> GetWithDetail(int planId)
        {
            var outputRequests = _outputRequestManager.GetWithDetails(planId).ToList();
            var result = ObjectMapper.Map<List<OutputRequestWithDetailDto>>(outputRequests);

            foreach (var outputRequestDto in result)
            {
                await InitialProduction(outputRequestDto);
            }
            return result;
        }

        private async Task InitialProduction(OutputRequestWithDetailDto outputRequestDto)
        {
            foreach (var requestProduct in outputRequestDto.OutputRequestProducts)
            {
                //Can produce
                var numberOfProducts = new List<int>();
                var formulas = requestProduct.Product.Formulas;
                foreach (var requestMaterial in outputRequestDto.OutputRequestMaterials)
                {
                    var formulla = formulas.FirstOrDefault(x => x.MaterialId == requestMaterial.WarehouseMaterial.MaterialId);
                    if (formulla != null)
                    {
                        var quantity = await _transferManager.ConvertTo(requestMaterial.UnitId, formulla.UnitId, requestMaterial.Quantity);
                        var numberOfProduce = (int)(quantity / formulla.Quantity);
                        numberOfProducts.Add(numberOfProduce);
                    }
                }
                requestProduct.CanProduce = numberOfProducts.Min() / (outputRequestDto.OutputRequestMaterials.Count);

                //Actual
                if (outputRequestDto.DailyProductions.Any())
                {
                    var dailyProductionDetails = outputRequestDto.DailyProductions
                        .SelectMany(x => x.DailyProductionDetails)
                        .Where(x => x.ProductId == requestProduct.ProductId);

                    requestProduct.ActualProduce = dailyProductionDetails.Sum(x => x.Quantity);
                }
            }
        }
        public async Task<OutputRequestDto> ChangeStatusAsync(int status, int id)
        {            
            var updatedOutputRequst = await _outputRequestManager.ChangeStatus((OutputRequestStatus)status, id);
            if (updatedOutputRequst == null)
            {
                throw new UserFriendlyException("Change Error");
            }
            if (status == 1)
            {
                var outputRequest = await Task.FromResult(_outputRequestManager.GetOutputRequestWithDetails(id));
                foreach (var outputRequestMaterial in outputRequest.OutputRequestMaterials)
                {
                    EventBus.Default
                        .Trigger(new ModifyCurrentQuantityOfWarehouseMaterialData(outputRequestMaterial.WarehouseMaterialId, outputRequestMaterial.Quantity, outputRequestMaterial.UnitId));
                }
            }
            return ObjectMapper.Map<OutputRequestDto>(updatedOutputRequst);
        }
    }
}
