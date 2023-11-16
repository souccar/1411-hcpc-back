﻿using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.Units.Dto.Transfers;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Transfers.Services.Transfers
{
    public interface ITransferAppService : IAsyncSouccarAppService<TransferDto, int, PagedTransferRequestDto, CreateTransferDto, UpdateTransferDto>
    {
        Task<ConvertToOutputDto> ConvertTo(ConvertToInputDto input);
    }
}
