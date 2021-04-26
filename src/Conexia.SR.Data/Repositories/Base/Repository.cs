using Conexia.Core.Data;
using Conexia.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Conexia.SR.Data.Repositories.Base
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        public SRContext Context { get; protected set; }
        public virtual DbSet<TEntity> DbSet { get; protected set; }
        protected Repository(SRContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public IUnitOfWork UnitOfWork => Context;
        public async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public void Create(TEntity entity)
        {
            DbSet.Add(entity);
        }
        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
