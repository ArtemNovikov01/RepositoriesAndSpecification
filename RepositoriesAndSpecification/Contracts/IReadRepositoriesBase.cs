using Specifications;
using Specifications.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IReadRepositoriesBase<TEntity> where TEntity : class
    {
        TEntity GetById<TKey>(TKey id) where TKey : struct;
        TEntity GetBySpecification(ISpecification<TEntity> specification);
        List<TEntity> List();
        List<TEntity> List(ISpecification<TEntity> specification);
        IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification);
    }
}
