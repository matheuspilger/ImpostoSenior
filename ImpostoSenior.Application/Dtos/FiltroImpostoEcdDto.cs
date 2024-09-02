namespace ImpostoSenior.Application.Dtos
{
    public class FiltroImpostoEcdDto
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string Cnpj { get; set; } = default!;
        public string Hash { get; set; } = default!;
    }
}
