using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Souccar.hr.Personnel.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Souccar.Core.Services
{
    public class SouccarDomainService<TEntity, TPrimaryKey> : ISouccarDomainService<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly IRepository<TEntity, TPrimaryKey> _repository;

        public SouccarDomainService(IRepository<TEntity, TPrimaryKey> repository)
        {
            _repository = repository;
        }

        public virtual void Delete(TPrimaryKey id)
        {
            _repository.Delete(id);
        }

        public async Task DeleteAsync(TPrimaryKey id)
        {
            await _repository.DeleteAsync(id);
        }

        public TEntity Get(TPrimaryKey id)
        {
            return _repository.Get(id);
        }


        public IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<TEntity> GetAgreggateAsync(TPrimaryKey id)
        {
            
            var properties = typeof(TEntity).GetProperties()
                .Where(x => 
                    x.PropertyType.IsGenericType && 
                    x.PropertyType.GetGenericTypeDefinition() == typeof(IList<>));

            if (properties.Any())
            {
                var lambdaExp = new List<Expression<Func<TEntity, object>>>();
                foreach (var prop in properties)
                {
                    var paramName = prop.Name.Substring(0, 2).ToLower();
                    var parameter = Expression.Parameter(typeof(TEntity), paramName);
                    var member = Expression.Property(parameter, prop.Name);
                    var finalExpression = Expression.Lambda<Func<TEntity, object>>(member, parameter);
                    lambdaExp.Add(finalExpression);
                }
                var result = _repository.GetAllIncluding(lambdaExp.ToArray()).FirstOrDefault("Id == @0", id);
                return Task.FromResult<TEntity>(result);
            }
            return GetAsync(id);
        }

        public async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await _repository.GetAsync(id);
        }

        public TEntity Insert(TEntity input)
        {
            var id = _repository.InsertAndGetId(input);
            return Get(id);
        }

        public async Task<TEntity> InsertAsync(TEntity input)
        {
            var id = await _repository.InsertAndGetIdAsync(input);
            return await GetAsync(id);
        }

        public virtual TEntity Update(TEntity input)
        {
            return _repository.Update(input);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity input)
        {
            return await _repository.UpdateAsync(input);
        }
    }
}
