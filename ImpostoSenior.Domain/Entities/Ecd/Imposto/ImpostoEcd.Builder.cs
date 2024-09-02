using ImpostoSenior.Domain.Enums.Ecd;

namespace ImpostoSenior.Domain.Entities.Ecd.Imposto
{
    public partial class ImpostoEcd
    {
        public static class Builder
        {
            public static ImpostoEcd Build(
                DateTime dataLancamento, 
                int codigoContabil, 
                IndicadorNatureza indicador, 
                decimal valorOriginal, 
                decimal percentual,
                string referencia)
                => new (dataLancamento, codigoContabil, indicador, valorOriginal, percentual, referencia);
        }
    }
}
