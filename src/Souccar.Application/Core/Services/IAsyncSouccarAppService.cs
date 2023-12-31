﻿using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System.Threading.Tasks;

namespace Souccar.Core.Services
{
    public interface IAsyncSouccarAppService<TEntityDto, TPrimaryKey,TGetAllInput, TCreateInput, TUpdateInput>
        : IApplicationService
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
    {
        Task<TEntityDto> GetAsync(EntityDto<TPrimaryKey> input);

        Task<TUpdateInput> GetForEditAsync(EntityDto<TPrimaryKey> input);

        Task<PagedResultDto<TEntityDto>> GetAllAsync(TGetAllInput input);

        Task<TEntityDto> CreateAsync(TCreateInput input);

        Task<TEntityDto> UpdateAsync(TUpdateInput input);

        Task DeleteAsync(EntityDto<TPrimaryKey> input);
    }
}
