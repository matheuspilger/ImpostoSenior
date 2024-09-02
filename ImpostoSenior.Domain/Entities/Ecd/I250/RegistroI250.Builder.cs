using ImpostoSenior.Domain.Enums.Ecd;
using ImpostoSenior.Domain.Helpers;

namespace ImpostoSenior.Domain.Entities.Ecd.I250
{
    public partial class RegistroI250
    {
        public class Builder
        {
            public static RegistroI250 Build(string linhaDoRegistro)
            {
                var itens = linhaDoRegistro.Values();
                var codigoContaAnalitica = itens.ToInt(Propriedade.OfType(nameof(CodigoContaAnalitica)));
                var codigoCentroCusto = itens.ToIntNull(Propriedade.OfType(nameof(CodigoCentroCusto)));
                var valor = itens.ToDecimal(Propriedade.OfType(nameof(Valor)));
                var indicadorNatureza = itens.GetEnum<IndicadorNatureza>(Propriedade.OfType(nameof(IndicadorNatureza)));
                var numeroArquivo = itens.ToValue(Propriedade.OfType(nameof(NumeroArquivo)));
                var codigoHistoricoPadrao = itens.ToIntNull(Propriedade.OfType(nameof(CodigoHistoricoPadrao)));
                var historico = itens.ToValue(Propriedade.OfType(nameof(Historico)));
                var codigoParticipante = itens.ToIntNull(Propriedade.OfType(nameof(CodigoParticipante)));

                var registro = new RegistroI250(
                    codigoContaAnalitica,
                    codigoCentroCusto,
                    valor,
                    indicadorNatureza,
                    numeroArquivo,
                    codigoHistoricoPadrao,
                    historico,
                    codigoParticipante);

                return registro;
            }
        }
    }
}
