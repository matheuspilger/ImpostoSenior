namespace ImpostoSenior.Domain.Entities.Ecd.I250
{
    public partial class RegistroI250
    {
        public static Constant Propriedade => new();

        public class Constant : PropriedadeConstante
        {
            public override IEnumerable<PropriedadeRegistro> ListOfProperties()
                => [new (nameof(CodigoContaAnalitica), 1),
                    new (nameof(CodigoCentroCusto), 2),
                    new (nameof(Valor), 3),
                    new (nameof(IndicadorNatureza), 4),
                    new (nameof(NumeroArquivo), 5),
                    new (nameof(CodigoHistoricoPadrao), 6),
                    new (nameof(Historico), 7),
                    new (nameof(CodigoParticipante), 8)];
        }
    }
}