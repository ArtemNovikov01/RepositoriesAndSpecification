using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specifications.Contracts
{
    // Summary:
    //     Specifications
    //     представляет абстракцию спецификации, включающей логику формирования запроса
    //     к базе данных.
    //
    // Type parameters:
    //   TResult:
    //     Тип результата, возвращаемого базой данных.
    public interface ISpecification<TResult> where TResult : class
    {
        // Summary:
        //     Применяет логику формирования запроса к базе данных к set.
        //
        // Returns:
        //     System.Linq.IQueryable`1, к которому была применена логика формирования запроса
        //     к базе данных.
        IQueryable<TResult> ApplySpecification(IQueryable<TResult> set);
    }
}
