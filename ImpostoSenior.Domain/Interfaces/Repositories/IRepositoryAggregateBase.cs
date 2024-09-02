using ImpostoSenior.Domain.Interfaces.Filters;

namespace ImpostoSenior.Domain.Interfaces.Repositories
{
    public interface IRepositoryAggregateBase<TEntity>
    {
        Task Aggregate(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> Get(IFilterBase filterBase, CancellationToken cancellationToken);
    }
}