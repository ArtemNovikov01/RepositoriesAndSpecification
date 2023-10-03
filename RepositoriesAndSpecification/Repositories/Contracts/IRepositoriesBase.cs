namespace RepositoriesAndSpecification.Repositories.Contracts
{
    public interface IRepositoriesBase<TEntity> : IReadRepositoriesBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete<TKey>(TKey id) where TKey : struct;
    }
}
