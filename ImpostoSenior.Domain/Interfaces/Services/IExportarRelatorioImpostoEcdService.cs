using ImpostoSenior.Domain.Filters.Ecd;

namespace ImpostoSenior.Domain.Interfaces.Services
{
    public interface IExportarRelatorioImpostoEcdService
    {
        Task Export(FiltroCalculoImpostoEcd filter, CancellationToken cancellationToken);
    }
}