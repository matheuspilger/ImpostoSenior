using ImpostoSenior.Domain.Entities.Ecd.C040;
using ImpostoSenior.Domain.Interfaces.Repositories.Ecd;
using ImpostoSenior.Infrastructure.Contexts.Interfaces;

namespace ImpostoSenior.Infrastructure.Repositories.Ecd
{
    public class RepositoryC040(IMongoDbContext mongoDbContext) : RepositoryBase<RegistroC040>(mongoDbContext), IRepositoryC040 { }
}
