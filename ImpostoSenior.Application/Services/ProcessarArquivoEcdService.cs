using ImpostoSenior.Domain.Factories.Ecd;
using ImpostoSenior.Domain.Interfaces.Repositories.Ecd;
using ImpostoSenior.Domain.Interfaces.Services;

namespace ImpostoSenior.Application.Services
{
    public class ProcessarArquivoEcdService(IRepositoryEcd repositoryEcd) : IProcessarArquivoEcdService
    {
        private readonly IRepositoryEcd _repositoryEcd = repositoryEcd;

        public async Task Process(IEnumerable<string> lines, CancellationToken cancellationToken)
        {
            var registroEcd = RegistroFactoryEcd.Instance.Fabricate(lines).First();
            await _repositoryEcd.Aggregate(registroEcd, cancellationToken);
        }
    }
}