using Abp.Dependency;
using Abp.Domain.Entities;
using System.Linq;

namespace Souccar.Core.Filter
{
    public interface IFilterBuilder<TEntity, TPrimaryKey>
        where TEntity : IEntity<TPrimaryKey>
    {
        IQueryable<TEntity> Filter(IQueryable<TEntity> queryable, string filtering);
    }
}
