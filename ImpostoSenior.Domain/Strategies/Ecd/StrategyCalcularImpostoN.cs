using ImpostoSenior.Domain.Entities.Ecd.I200;
using ImpostoSenior.Domain.Entities.Ecd.Imposto;
using ImpostoSenior.Domain.Enums.Ecd;
using ImpostoSenior.Domain.Interfaces.Strategies;

namespace ImpostoSenior.Domain.Strategies.Ecd
{
    public class StrategyCalcularImpostoN : StrategyCalcularImposto, IStrategyImpostoEcd
    {
        public static StrategyCalcularImpostoN Init() => new();

        private const decimal _percentualDia1Ao15 = 1.02M;
        private const decimal _percentualDia16Ao30 = 1.89M;

        protected override decimal GetPercentual(DateTime dataLancamento)
        => dataLancamento.Day >= 1 && dataLancamento.Day <= 15 ? _percentualDia1Ao15 : _percentualDia16Ao30;

        public override IEnumerable<ImpostoEcd> Calculate(IEnumerable<RegistroI200> registros)
        {
            var registrosI200 = registros.Where(r => r.Indicador == IndicadorLancamento.Normal);
            return base.Calculate(registrosI200);
        }
    }
}
