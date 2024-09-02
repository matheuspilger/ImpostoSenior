using ImpostoSenior.Domain.Filters.Ecd;
using ImpostoSenior.Domain.Interfaces.Repositories.Ecd;
using ImpostoSenior.Domain.Interfaces.Services;
using ImpostoSenior.Domain.Strategies.Ecd;

namespace ImpostoSenior.Application.Services
{
    public class CalcularImpostoEcdService(IRepositoryEcd repositoryEcd, IRepositoryImpostoEcd repositoryImpostoEcd) : ICalcularImpostoEcdService
    {
        private readonly IRepositoryEcd _repositoryEcd = repositoryEcd;
        private readonly IRepositoryImpostoEcd _repositoryImpostoEcd = repositoryImpostoEcd;
        private readonly StrategyCalcular _strategyCalcularImposto = StrategyCalcular.Init();

        public async Task Calculate(FiltroCalculoImpostoEcd filter, CancellationToken cancellationToken)
        {
            var registroEcd = await _repositoryEcd.Get(filter, cancellationToken);
            
            var registrosImpostoEcd = _strategyCalcularImposto
                .SetStrategy(StrategyCalcularImpostoE.Init())
                .Calculate(registroEcd.RegistrosI200).ToList();

            registrosImpostoEcd.AddRange(_strategyCalcularImposto
                .SetStrategy(StrategyCalcularImpostoN.Init())
                .Calculate(registroEcd.RegistrosI200));

            registrosImpostoEcd.AddRange(_strategyCalcularImposto
                .SetStrategy(StrategyCalcularImpostoX.Init())
                .Calculate(registroEcd.RegistrosI200));

            await _repositoryImpostoEcd.DeleteAndInsertMany(registrosImpostoEcd, x => x.Referencia == registroEcd.RegistroC040.Id.ToString(), cancellationToken);
        }
    }
}
