using Microsoft.EntityFrameworkCore;
using RepositoriesAndSpecification.Repositories.Contracts;

namespace RepositoriesAndSpecification.Repositories
{
    public abstract class RepositoriesBase<TEntity> : ReadRepositoriesBase<TEntity>, IRepositoriesBase<TEntity>, IReadRepositoriesBase<TEntity> where TEntity : class
    {
        protected RepositoriesBase(DbContext context)
            : base(context)
        {
        }

        public virtual void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void AddRange(IEnumerable<TEntity> entity)
        {
            _context.Set<TEntity>().AddRange(entity);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual void Delete<TKey>(TKey id) where TKey : struct
        {
            TEntity byId = GetById(id);
            Delete(byId);
        }
    }
}