using Abp.Application.Services.Dto;
using Abp.Application.Services;
using Abp.Domain.Entities;
using Abp.Linq;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace Souccar.Core.Services
{
    public abstract class AsyncSouccarAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
       : CrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>,
        IAsyncCrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
           where TEntity : class, IEntity<TPrimaryKey>
           where TEntityDto : IEntityDto<TPrimaryKey>
           where TUpdateInput : IEntityDto<TPrimaryKey>
           where TGetInput : IEntityDto<TPrimaryKey>
           where TDeleteInput : IEntityDto<TPrimaryKey>
    {
        public IAsyncQueryableExecuter AsyncQueryableExecuter { get; set; }

        protected AsyncSouccarAppService(ISouccarDomainService<TEntity, TPrimaryKey> domainService)
            : base(domainService)
        {

        }

        public virtual async Task<TEntityDto> GetAsync(TGetInput input)
        {
            CheckGetPermission();

            var entity = await GetEntityByIdAsync(input.Id);
            return MapToEntityDto(entity);
        }

        public virtual async Task<PagedResultDto<TEntityDto>> GetAllAsync(TGetAllInput input)
        {
            CheckGetAllPermission();

            var query = CreateFilteredQuery(input);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplyFiltering(query, input);
            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<TEntityDto>(
                totalCount,
                entities.Select(MapToEntityDto).ToList()
            );
        }

        public virtual async Task<TEntityDto> CreateAsync(TCreateInput input)
        {
            CheckCreatePermission();

            var entity = MapToEntity(input);

            await _domainService.InsertAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity);
        }

        public virtual async Task<TEntityDto> UpdateAsync(TUpdateInput input)
        {
            CheckUpdatePermission();

            var entity = await GetEntityByIdAsync(input.Id);

            MapToEntity(input, entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity);
        }

        public virtual Task DeleteAsync(TDeleteInput input)
        {
            CheckDeletePermission();

            return _domainService.DeleteAsync(input.Id);
        }

        protected virtual Task<TEntity> GetEntityByIdAsync(TPrimaryKey id)
        {
            if (typeof(TEntity).IsSubclassOf(typeof(FullAuditedAggregateRoot)))
            {
                return _domainService.GetAgreggateAsync(id);
            }
            return _domainService.GetAsync(id);
        }
    }
}