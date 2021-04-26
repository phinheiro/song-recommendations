using Conexia.Core.DomainObjects;
using System;
using System.Threading.Tasks;

namespace Conexia.Core.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        IUnitOfWork UnitOfWork { get; }
        Task<TEntity> GetById(Guid id);
        void Create(TEntity entity);
    }
}
