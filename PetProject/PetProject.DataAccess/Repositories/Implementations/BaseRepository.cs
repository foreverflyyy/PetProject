using Microsoft.EntityFrameworkCore;
using PetProject.DataAccess.Repositories.Interfaces;
using PetProject.DataContext.Interfaces;
using PetProject.Entities.Base;

namespace PetProject.DataAccess.Repositories.Implementations
{
    public class BaseRepository<TContext, TEntity, T> : IRepository<TContext, TEntity, T>
        where TEntity : BaseEntity<T>
        where TContext : class, IContext
    where T : struct
    {
        protected readonly TContext Context;

        public BaseRepository(TContext context)
        {
            Context = context;
        }

        #region IRepository

        /// <inheritdoc />
        public virtual IQueryable<TEntity> GetAll(bool tracking = false)
            => tracking ? Context.Set<TEntity>() : Context.Set<TEntity>().AsNoTracking();

        /// <inheritdoc />
        public virtual TEntity GetById(T id)
            => Context.Set<TEntity>().Find(id);

        /// <inheritdoc />
        public virtual bool Exists(T id)
            => Context.Set<TEntity>().Any(x => Equals(x.Id, id));

        /// <inheritdoc />
        public virtual void Add(TEntity entity)
            => Context.Set<TEntity>().Add(entity);

        public virtual void AddRange(IEnumerable<TEntity> entities)
            => Context.Set<TEntity>().AddRange(entities);

        /// <inheritdoc />
        public virtual void Update(TEntity entity)
            => Context.Set<TEntity>().Update(entity);

        /// <inheritdoc />
        public virtual void Remove(TEntity entity)
            => Context.Set<TEntity>().Remove(entity);

        /// <inheritdoc />
        public virtual void Remove(T id)
            => Context.Set<TEntity>().Remove(GetById(id));

        /// <inheritdoc />
        public virtual void RemoveRange(IEnumerable<T> ids)
            => Context.Set<TEntity>().RemoveRange(ids.Select(GetById));

        /// <inheritdoc />
        public virtual int SaveChanges()
            => Context.SaveChanges();

        /// <inheritdoc />
        public virtual void SaveChangesAndDetach()
        {
            Context.SaveChanges();

            var entries = Context.ChangeTracker.Entries().ToList();
            foreach (var entry in entries)
            {
                entry.State = EntityState.Detached;
            }
        }

        #endregion
    }
}
