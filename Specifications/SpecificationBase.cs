using Specifications.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specifications
{
    public abstract class SpecificationBase<Type> : ISpecification<Type> where Type : class
    {
        Func<IQueryable<Type>, IQueryable<Type>> _query { get; set; }
        public SpecificationBase(Func<IQueryable<Type>, IQueryable<Type>> query) 
        {
            _query = query;
        }
        public IQueryable<Type> ApplySpecification(IQueryable<Type> set)
        {
            return _query(set);
        }
    }
}
