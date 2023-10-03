using Specifications.Contracts;

namespace Specifications
{
    public abstract class SpecificationBase<Type> : ISpecification<Type> where Type : class
    {
        private readonly Func<IQueryable<Type>, IQueryable<Type>> _query;
        protected SpecificationBase(Func<IQueryable<Type>, IQueryable<Type>> query) 
        {
            _query = query;
        }
        public IQueryable<Type> ApplyTo(IQueryable<Type> set)
        {
            return _query(set);
        }
    }
}
