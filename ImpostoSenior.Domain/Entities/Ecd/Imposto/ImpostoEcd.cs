namespace ImpostoSenior.Domain.Entities.Ecd.Imposto
{
    public partial class ImpostoEcd : EntidadeBase
    {
        public DateTime DataLancamento { get; set; }
        public int CodigoContabil { get; set; }
        public decimal ValorOriginal { get; set; }
        public decimal ValorCalculado { get; set; }
    }
}
