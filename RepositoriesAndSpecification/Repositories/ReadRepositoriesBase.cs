using Microsoft.EntityFrameworkCore;
using RepositoriesAndSpecification.Repositories.Contracts;
using Specifications.Contracts;

namespace RepositoriesAndSpecification.Repositories
{
    public class ReadRepositoriesBase<TEntity> : DbContext, IReadRepositoriesBase<TEntity> where TEntity : class
    {
        private protected readonly DbContext _context;

        protected ReadRepositoriesBase(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Возвращает один элемент с Id == id.
        /// </summary>
        public virtual TEntity GetById<TKey>(TKey id) where TKey : struct
        {
            return _context.Set<TEntity>().Find(id);
        }

        /// <summary>
        ///     Принимает описание по которому нужно получить элемент из базы данных.
        /// </summary>
        /// <param name="specification">
        ///     Инстукция вытягивания данных из БД.
        /// </param>
        public virtual TEntity GetBySpecification(ISpecification<TEntity> specification)
        {
            return ApplySpecification(specification).FirstOrDefault();
        }

        public virtual List<TEntity> List()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual List<TEntity> List(ISpecification<TEntity> specification)
        {
            return ApplySpecification(specification).ToList();
        }

        public IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
        {
            if (specification == null)
                throw new ArgumentNullException("specification");

            return specification.ApplyTo(_context.Set<TEntity>().AsQueryable());
        }
    }
}
