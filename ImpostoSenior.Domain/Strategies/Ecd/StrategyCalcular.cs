using ImpostoSenior.Domain.Entities.Ecd.I200;
using ImpostoSenior.Domain.Entities.Ecd.Imposto;
using ImpostoSenior.Domain.Interfaces.Strategies;

namespace ImpostoSenior.Domain.Strategies.Ecd
{
    public class StrategyCalcular
    {
        public static StrategyCalcular Init() => new ();

        private IStrategyImpostoEcd _strategy = default!;

        public StrategyCalcular SetStrategy(IStrategyImpostoEcd strategy)
        {
            _strategy = strategy;
            return this;
        }

        public IEnumerable<ImpostoEcd> Calculate(IEnumerable<RegistroI200> registros)
        {
            return _strategy.Calculate(registros);
        }
    }
}
