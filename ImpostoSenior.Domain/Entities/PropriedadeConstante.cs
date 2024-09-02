namespace ImpostoSenior.Domain.Entities
{
    public abstract class PropriedadeConstante
    {
        public abstract IEnumerable<PropriedadeRegistro> ListOfProperties();

        public int OfType(string propriedade)
            => ListOfProperties().First(p => p.Propriedade == propriedade).Posicao;
    }
}
