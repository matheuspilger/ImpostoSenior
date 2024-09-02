namespace ImpostoSenior.Domain.Interfaces.Services
{
    public interface IProcessarArquivoEcdService
    {
        Task Process(IEnumerable<string> lines, CancellationToken cancellationToken);
    }
}
