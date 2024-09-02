using ImpostoSenior.Domain.Entities.Ecd.Imposto;
using ImpostoSenior.Domain.Filters.Ecd;
using ImpostoSenior.Domain.Interfaces.Filters;
using ImpostoSenior.Domain.Interfaces.Repositories.Ecd;
using ImpostoSenior.Infrastructure.Contexts.Interfaces;

namespace ImpostoSenior.Infrastructure.Repositories.Ecd
{
    public class RepositoryImpostoEcd(IMongoDbContext mongoDbContext, IRepositoryC040 repositoryC040) : RepositoryBase<ImpostoEcd>(mongoDbContext), IRepositoryImpostoEcd
    {
        private readonly IMongoDbContext _mongoDbContext = mongoDbContext;
        private readonly IRepositoryC040 _repositoryC040 = repositoryC040;

        public async Task<IEnumerable<ImpostoEcd>> GetMany(IFilterBase filterBase, CancellationToken cancellationToken)
        {
            var filtro = (FiltroCalculoImpostoEcd)filterBase;
            var registroC040 = await _repositoryC040.FindOne(filtro.GetFilter(), cancellationToken);
            var registrosImpostoEcd = await FindMany(x => x.Referencia == registroC040.Id.ToString(), cancellationToken);
            return registrosImpostoEcd;
        }
    }
}
