using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System.Threading.Tasks;

namespace Souccar.Core.Services
{
    public interface IAsyncSouccarAppService<TEntityDto, TPrimaryKey, in TGetAllInput, in TCreateInput, in TUpdateInput, in TGetInput, in TDeleteInput>
        : IApplicationService
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
        where TGetInput : IEntityDto<TPrimaryKey>
        where TDeleteInput : IEntityDto<TPrimaryKey>
    {
        Task<TEntityDto> GetAsync(TGetInput input);

        Task<PagedResultDto<TEntityDto>> GetAllAsync(TGetAllInput input);

        Task<TEntityDto> CreateAsync(TCreateInput input);

        Task<TEntityDto> UpdateAsync(TUpdateInput input);

        Task DeleteAsync(TDeleteInput input);
    }
}
