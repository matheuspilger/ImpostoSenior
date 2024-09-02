using ImpostoSenior.Domain.Enums.Ecd;
using ImpostoSenior.Domain.Helpers;

namespace ImpostoSenior.Domain.Entities.Ecd.I200
{
    public partial class RegistroI200
    {
        public static class Builder
        {
            public static RegistroI200 Build(string linhaDoRegistro)
            {
                var itens = linhaDoRegistro.Values();
                var numero = itens.ToValue(Propriedade.OfType(nameof(Numero)));
                var data = itens.ToDateTime(Propriedade.OfType(nameof(Data)));
                var valor = itens.ToDecimal(Propriedade.OfType(nameof(Valor)));
                var indicador = itens.GetEnum<IndicadorLancamento>(Propriedade.OfType(nameof(Indicador)));
                var dataExtemporaneo = itens.ToDateTimeNull(Propriedade.OfType(nameof(DataExtemporaneo)));

                return new RegistroI200(numero, data, valor, indicador, dataExtemporaneo);
            }
        }
    }
}
