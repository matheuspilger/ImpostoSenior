using ImpostoSenior.Domain.Entities.Ecd.I250;
using ImpostoSenior.Domain.Enums.Ecd;

namespace ImpostoSenior.Domain.Entities.Ecd.I200
{
    public partial class RegistroI200
    {
        public string Numero { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public IndicadorLancamento Indicador { get; set; }
        public DateTime? DataExtemporaneo { get; set; }
        public IList<RegistroI250> Itens { get; set; }

    }
}
