namespace ImpostoSenior.Domain.Entities
{
    public class PropriedadeRegistro
    {
        public PropriedadeRegistro(string propriedade, int posicao)
        {
            Propriedade = propriedade;
            Posicao = posicao;
        }

        public string Propriedade { get; }
        public int Posicao { get; }
    }
}
