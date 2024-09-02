namespace ImpostoSenior.Domain.Filters.Ecd
{
    public partial class FiltroCalculoImpostoEcd
    {
        public static class Builder
        {
            public static FiltroCalculoImpostoEcd Build(
                DateTime dataInicial, 
                DateTime dataFinal, 
                string cnpj, 
                string hash) => new(dataInicial, dataFinal, cnpj, hash);
        }
    }
}
