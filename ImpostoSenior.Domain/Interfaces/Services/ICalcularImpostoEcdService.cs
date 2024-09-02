using ImpostoSenior.Domain.Filters.Ecd;

namespace ImpostoSenior.Domain.Interfaces.Services
{
    public interface ICalcularImpostoEcdService
    {
        Task Calculate(FiltroCalculoImpostoEcd filter, CancellationToken cancellationToken);
    }
}
