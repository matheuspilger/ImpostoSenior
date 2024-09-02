namespace ImpostoSenior.Domain.Entities.Ecd.C040
{
    public partial class RegistroC040 : EntidadeBase
    {
        public string Hash { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string Cnpj { get; set; }
    }
}
