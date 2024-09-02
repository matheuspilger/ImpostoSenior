using ImpostoSenior.Domain.Entities.Ecd.I200;
using ImpostoSenior.Domain.Entities.Ecd.Imposto;

namespace ImpostoSenior.Domain.Interfaces.Strategies
{
    public interface IStrategyImpostoEcd
    {
        IEnumerable<ImpostoEcd> Calculate(IEnumerable<RegistroI200> registros);
    }
}
