using ImpostoSenior.Domain.Entities;
using System.Linq.Expressions;

namespace ImpostoSenior.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : EntidadeBase
    {
        Task AddOrUpdate(TEntity entity, Expression<Func<TEntity, bool>> filterBy, CancellationToken cancellationToken);
        Task DeleteAndInsertMany(IEnumerable<TEntity> entities, Expression<Func<TEntity, bool>> filterBy, CancellationToken cancellationToken);
        Task<TEntity> FindOne(Expression<Func<TEntity, bool>> filterBy, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> FindMany(Expression<Func<TEntity, bool>> filterBy, CancellationToken cancellationToken);
    }
}
