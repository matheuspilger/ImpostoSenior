using ImpostoSenior.Domain.Entities.Ecd.I200;
using ImpostoSenior.Domain.Interfaces.Repositories.Ecd;
using ImpostoSenior.Infrastructure.Contexts.Interfaces;

namespace ImpostoSenior.Infrastructure.Repositories.Ecd
{
    public class RepositoryI200(IMongoDbContext mongoDbContext) : RepositoryBase<RegistroI200>(mongoDbContext), IRepositoryI200 { }
}
