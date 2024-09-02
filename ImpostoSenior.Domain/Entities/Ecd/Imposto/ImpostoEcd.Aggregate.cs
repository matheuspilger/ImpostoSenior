using ImpostoSenior.Domain.Enums.Ecd;

namespace ImpostoSenior.Domain.Entities.Ecd.Imposto
{
    public partial class ImpostoEcd
    {
        public ImpostoEcd(DateTime dataLancamento, int codigoContabil, IndicadorNatureza indicador, decimal valorOriginal, decimal percentual, string referencia)
        {
            DataLancamento = dataLancamento;
            CodigoContabil = codigoContabil;
            SetValorOriginal(indicador, valorOriginal);
            CalculateImpostoEcd(percentual);
            SetReferencia(referencia);
        }

        private void SetValorOriginal(IndicadorNatureza indicador, decimal valorOriginal)
            => ValorOriginal = indicador == IndicadorNatureza.Credito ? +Math.Abs(valorOriginal) : -Math.Abs(valorOriginal);

        private void CalculateImpostoEcd(decimal percentual)
            => ValorCalculado = ValorOriginal + (ValorOriginal * (percentual / 100));
    }
}
