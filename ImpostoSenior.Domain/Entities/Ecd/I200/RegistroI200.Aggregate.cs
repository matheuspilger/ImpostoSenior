using ImpostoSenior.Domain.Entities.Ecd.I250;
using ImpostoSenior.Domain.Enums.Ecd;

namespace ImpostoSenior.Domain.Entities.Ecd.I200
{
    public partial class RegistroI200 : EntidadeBase
    {
        public RegistroI200(string numero, DateTime data, decimal valor, IndicadorLancamento indicador, DateTime? dataExtemporaneo)
        {
            Numero = numero;
            Data = data;
            Valor = valor;
            Indicador = indicador;
            DataExtemporaneo = dataExtemporaneo;

            Itens = [];
        }

        public void AddItem(string linhaDoRegisto)
            => Itens.Add(RegistroI250.Builder.Build(linhaDoRegisto));
    }
}
