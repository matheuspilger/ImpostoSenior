using ImpostoSenior.Domain.Enums.Ecd;

namespace ImpostoSenior.Domain.Entities.Ecd.I250
{
    public partial class RegistroI250
    {
        public int CodigoContaAnalitica { get; set; }
        public int? CodigoCentroCusto { get; set; }
        public decimal Valor { get; set; }
        public IndicadorNatureza IndicadorNatureza { get; set; }
        public string NumeroArquivo { get; set; }
        public int? CodigoHistoricoPadrao { get; set; }
        public string Historico { get; set; } = default!;
        public int? CodigoParticipante { get; set; }
    }
}