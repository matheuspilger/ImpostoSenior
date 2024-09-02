using ImpostoSenior.Domain.Entities.Ecd.Base;
using ImpostoSenior.Domain.Entities.Ecd.I200;
using ImpostoSenior.Domain.Filters.Ecd;
using ImpostoSenior.Domain.Interfaces.Filters;
using ImpostoSenior.Domain.Interfaces.Repositories.Ecd;

namespace ImpostoSenior.Infrastructure.Repositories.Ecd
{
    public class RepositoryEcd(IRepositoryC040 repositoryC040, IRepositoryI200 repositoryI200) : IRepositoryEcd
    {
        private readonly IRepositoryC040 _repositoryC040 = repositoryC040;
        private readonly IRepositoryI200 _repositoryI200 = repositoryI200;

        public async Task Aggregate(RegistroEcd entity, CancellationToken cancellationToken)
        {
            await _repositoryC040.AddOrUpdate(entity.RegistroC040, 
                x => x.Cnpj == entity.RegistroC040.Cnpj &&
                x.DataInicial == entity.RegistroC040.DataInicial &&
                x.DataFinal == entity.RegistroC040.DataFinal &&
                x.Hash == entity.RegistroC040.Hash, cancellationToken);

            await _repositoryI200.DeleteAndInsertMany(
                entity.RegistrosI200.Select(r => r.SetReferencia(entity.RegistroC040.Id.ToString())).OfType<RegistroI200>(), 
                x => x.Referencia == entity.RegistroC040.Id.ToString(), cancellationToken);
        }

        public async Task<RegistroEcd> Get(IFilterBase filterBase, CancellationToken cancellationToken)
        {
            var filtro = (FiltroCalculoImpostoEcd) filterBase;
            var registroC040 = await _repositoryC040.FindOne(filtro.GetFilter(), cancellationToken);
            var registrosCI200 = await _repositoryI200.FindMany(x => x.Referencia == registroC040.Id.ToString(), cancellationToken);
            return RegistroEcd.Builder.Build(registroC040, registrosCI200);
        }
    }
}