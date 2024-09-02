using ImpostoSenior.Domain.Entities;
using MongoDB.Driver;

namespace ImpostoSenior.Infrastructure.Contexts.Interfaces
{
    public interface IMongoDbContext
    {
        void Initialize();
        IMongoCollection<TEntity> GetCollection<TEntity>() where TEntity : EntidadeBase;
    }
}
