using ImpostoSenior.Domain.Enums.Ecd;

namespace ImpostoSenior.Domain.Entities.Ecd.I250
{
    public partial class RegistroI250
    {
        public RegistroI250(int codigoContaAnalitica, int? codigoCentroCusto, decimal valor, IndicadorNatureza indicadorNatureza, 
            string numeroArquivo, int? codigoHistoricoPadrao, string historico, int? codigoParticipante)
        {
            CodigoContaAnalitica = codigoContaAnalitica;
            CodigoCentroCusto = codigoCentroCusto;
            Valor = valor;
            IndicadorNatureza = indicadorNatureza;
            NumeroArquivo = numeroArquivo;
            CodigoHistoricoPadrao = codigoHistoricoPadrao;
            Historico = historico;
            CodigoParticipante = codigoParticipante;
        }

        public decimal GetValor()
            => IndicadorNatureza == IndicadorNatureza.Credito ? Valor : -Math.Abs(Valor);
    }
}
