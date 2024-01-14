using Abp.Application.Services.Dto;
using Abp.Application.Services;
using Abp.Domain.Entities;
using Abp.Linq;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using Souccar.Core.Services.Interfaces;
using Souccar.Core.Includes;
using Souccar.Core.Filter;
using Souccar.hr.Personnel.Employees.Dto;
using System.Collections.Generic;
using System;
using System.Linq.Dynamic.Core;

namespace Souccar.Core.Services
{
    public abstract class AsyncSouccarAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
       : CrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>,
        IAsyncCrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>, EntityDto<TPrimaryKey>>
           where TEntity : class, IEntity<TPrimaryKey>
           where TEntityDto : IEntityDto<TPrimaryKey>
           where TUpdateInput : IEntityDto<TPrimaryKey>
    {
        public IAsyncQueryableExecuter AsyncQueryableExecuter { get; set; }

        protected AsyncSouccarAppService(ISouccarDomainService<TEntity, TPrimaryKey> domainService)
            : base(domainService)
        {

        }

        public virtual async Task<TEntityDto> GetAsync(EntityDto<TPrimaryKey> input)
        {
            CheckGetPermission();

            var entity = await GetEntityByIdAsync(input.Id);
            return MapToEntityDto(entity);
        }

        public virtual async Task<TUpdateInput> GetForEditAsync(EntityDto<TPrimaryKey> input)
        {
            var data = await _domainService.GetAgreggateAsync(input.Id);
            return ObjectMapper.Map<TUpdateInput>(data);
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

        public virtual async Task<PagedResultDto<TEntityDto>> ReadAsync(TGetAllInput input)
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

        public IList<TEntityDto> Filter(FilterDto input)
        {
            CheckGetAllPermission();
            var values = input.Rules.Select(f => f.Value).ToArray();
            string predicate = "";

            if (input.Rules != null && input.Rules.Any())
            {
                for (var i = 0; i < input.Rules.Count; i++)
                {
                    string comparison = input.Rules[i].Operator;

                    if (comparison == "StartsWith" || comparison == "EndsWith" || comparison == "Contains")
                    {
                        if (i != input.Rules.Count - 1)
                        {
                            predicate += String.Format("{0}.{1}(@{2}) {3} ", input.Rules[i].Field, comparison, i, input.Condition);

                        }
                        else
                        {
                            predicate += String.Format("{0}.{1}(@{2}) ", input.Rules[i].Field, comparison, i);

                        }
                    }
                    else
                    {
                        if (i != input.Rules.Count - 1)
                        {
                            predicate += String.Format("{0} {1} @{2} {3} ", input.Rules[i].Field, comparison, i, input.Condition);

                        }
                        else
                        {
                            predicate += String.Format("{0} {1} @{2}", input.Rules[i].Field, comparison, i);

                        }
                    }
                }
            }

            var entities = _domainService.GetAll().Where(predicate, values).ToList();

            return entities.Select(MapToEntityDto).ToList();
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

        public virtual Task DeleteAsync(EntityDto<TPrimaryKey> input)
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