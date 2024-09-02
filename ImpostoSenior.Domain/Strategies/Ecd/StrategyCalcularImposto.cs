using ImpostoSenior.Domain.Entities.Ecd.I200;
using ImpostoSenior.Domain.Entities.Ecd.Imposto;
using ImpostoSenior.Domain.Enums.Ecd;
using ImpostoSenior.Domain.Helpers;
using ImpostoSenior.Domain.Interfaces.Strategies;

namespace ImpostoSenior.Domain.Strategies.Ecd
{
    public abstract class StrategyCalcularImposto : IStrategyImpostoEcd
    {
        private const int _codigoContabilStartsWith = 1;
        protected abstract decimal GetPercentual(DateTime dataLancamento = default);

        public virtual IEnumerable<ImpostoEcd> Calculate(IEnumerable<RegistroI200> registros)
        {
            var registrosImpostosEcd = new List<ImpostoEcd>();

            foreach (var registroI200 in registros)
            {
                var registrosI250 = registroI200.Itens.GroupBy(r => r.CodigoContaAnalitica);

                var percentual = GetPercentual(registroI200.Data);

                var registrosProcessados = registrosI250.Select(registroI250 =>
                    ImpostoEcd.Builder.Build(
                        registroI200.Data,
                        registroI250.Key,
                        registroI250.Key.StartsWith(_codigoContabilStartsWith) ? IndicadorNatureza.Debito : IndicadorNatureza.Credito,
                        registroI250.Sum(r => r.GetValor()), percentual,
                        registroI200.Referencia!));
                registrosImpostosEcd.AddRange(registrosProcessados);
            }

            return registrosImpostosEcd;
        }
    }
}
