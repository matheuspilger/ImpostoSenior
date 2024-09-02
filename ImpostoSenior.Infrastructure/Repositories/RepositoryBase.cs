using ImpostoSenior.Domain.Entities;
using ImpostoSenior.Domain.Interfaces.Repositories;
using ImpostoSenior.Infrastructure.Contexts.Interfaces;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace ImpostoSenior.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntidadeBase
    {
        private readonly IMongoCollection<TEntity> _collection;

        public RepositoryBase(IMongoDbContext mongoDbContext)
        {
            _collection = mongoDbContext.GetCollection<TEntity>();
        }

        public async Task AddOrUpdate(TEntity entity, Expression<Func<TEntity, bool>> filterBy, CancellationToken cancellationToken)
        {
            var options = new FindOneAndReplaceOptions<TEntity>
            {
                ReturnDocument = ReturnDocument.After
            };

            var result = await _collection.FindOneAndReplaceAsync(filterBy, entity, options, cancellationToken: cancellationToken);
            entity.SetId(result.Id);
        }

        public async Task DeleteAndInsertMany(IEnumerable<TEntity> entities, Expression<Func<TEntity, bool>> filterBy, CancellationToken cancellationToken)
        {
            await _collection.DeleteManyAsync(filterBy, cancellationToken: cancellationToken);
            await _collection.InsertManyAsync(entities, cancellationToken: cancellationToken);
        }

        public async Task<TEntity> FindOne(Expression<Func<TEntity, bool>> filterBy, CancellationToken cancellationToken)
        {
            return await _collection.Find(filterBy).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> FindMany(Expression<Func<TEntity, bool>> filterBy, CancellationToken cancellationToken)
        {
            return await _collection.Find(filterBy).ToListAsync(cancellationToken);
        }
    }
}