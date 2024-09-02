using ImpostoSenior.Domain.Entities.Ecd.I200;
using ImpostoSenior.Domain.Entities.Ecd.Imposto;
using ImpostoSenior.Domain.Enums.Ecd;
using ImpostoSenior.Domain.Interfaces.Strategies;

namespace ImpostoSenior.Domain.Strategies.Ecd
{
    public class StrategyCalcularImpostoX : StrategyCalcularImposto, IStrategyImpostoEcd
    {
        public static StrategyCalcularImpostoX Init() => new();

        private const decimal _percentual = 2.56M;

        protected override decimal GetPercentual(DateTime dataLancamento) => _percentual;

        public override IEnumerable<ImpostoEcd> Calculate(IEnumerable<RegistroI200> registros)
        {
            var registrosI200 = registros.Where(r => r.Indicador == IndicadorLancamento.Extemporaneo);
            return base.Calculate(registrosI200);
        }
    }
}