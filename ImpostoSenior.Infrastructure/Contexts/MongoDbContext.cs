using ImpostoSenior.Domain.Configurations;
using ImpostoSenior.Domain.Entities;
using ImpostoSenior.Infrastructure.Constants;
using ImpostoSenior.Infrastructure.Contexts.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace ImpostoSenior.Infrastructure.Contexts
{
    public class MongoDbContext(IOptions<DatabaseConfig> config) : IMongoDbContext
    {
        private readonly DatabaseConfig _databaseConfig = config.Value;
        private IMongoDatabase _database = default!;

        public void Initialize()
        {
            var client = new MongoClient(_databaseConfig.ConnectionString);
            _database = client.GetDatabase(_databaseConfig.DatabaseName);

            var pack = new ConventionPack
            {
                new IgnoreIfNullConvention(true)
            };

            ConventionRegistry.Register(Ignore.NullProperty, pack, filter => filter.Assembly == typeof(EntidadeBase).Assembly);
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>() where TEntity : EntidadeBase
            => _database.GetCollection<TEntity>(typeof(TEntity).Name);
    }
}
