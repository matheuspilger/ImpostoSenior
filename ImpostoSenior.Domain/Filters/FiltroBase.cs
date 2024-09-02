using ImpostoSenior.Domain.Interfaces.Filters;
using LinqKit;
using System.Linq.Expressions;

namespace ImpostoSenior.Domain.Filters
{
    public class FiltroBase<TEntity> : IFilterBase
    {
        public virtual Expression<Func<TEntity, bool>> GetFilter()
        {
            return PredicateBuilder.New<TEntity>(true);
        }
    }
}
