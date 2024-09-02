using ImpostoSenior.Domain.Helpers;

namespace ImpostoSenior.Domain.Entities.Ecd.C040
{
    public partial class RegistroC040
    {
        public static class Builder
        {
            public static RegistroC040 Build(string linhaDoRegistro)
            {
                var itens = linhaDoRegistro.Values();
                var hash = itens.ToValue(Propriedade.OfType(nameof(Hash)));
                var dataInicial = itens.ToDateTime(Propriedade.OfType(nameof(DataInicial)));
                var dataFinal = itens.ToDateTime(Propriedade.OfType(nameof(DataFinal)));
                var cnpj = itens.ToValue(Propriedade.OfType(nameof(Cnpj)));

                return new RegistroC040(hash, dataInicial, dataFinal, cnpj);
            }
        }
    }
}
