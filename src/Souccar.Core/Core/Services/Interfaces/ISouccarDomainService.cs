using Abp.Domain.Entities;
using System.Threading.Tasks;

namespace Souccar.Core.Services.Interfaces
{
    public interface ISouccarDomainService<TEntity, TPrimaryKey> : IDeleteSouccarDomainService<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        
    }
}
