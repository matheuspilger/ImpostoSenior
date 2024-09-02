namespace ImpostoSenior.Domain.Entities.Ecd.C040
{
    public partial class RegistroC040
    {
        public RegistroC040(string hash, DateTime dataInicial, DateTime dataFinal, string cnpj)
        {
            Hash = hash;
            DataInicial = dataInicial;
            DataFinal = dataFinal;
            Cnpj = cnpj;
        }
    }
}
