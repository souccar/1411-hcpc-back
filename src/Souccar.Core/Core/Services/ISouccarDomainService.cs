using Abp.Domain.Entities;
using Abp.Domain.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Core.Services
{
    public interface ISouccarDomainService<TEntity, TPrimaryKey> : IDomainService
        where TEntity : class, IEntity<TPrimaryKey>
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(TPrimaryKey id);
        TEntity Insert(TEntity input);
        TEntity Update(TEntity input);
        void Delete(TPrimaryKey id);
        Task<TEntity> GetAsync(TPrimaryKey id);
        Task<TEntity> GetAgreggateAsync(TPrimaryKey id);
        Task<TEntity> InsertAsync(TEntity input);
        Task<TEntity> UpdateAsync(TEntity input);
        Task DeleteAsync(TPrimaryKey id);
    }
}
