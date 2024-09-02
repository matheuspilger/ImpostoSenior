namespace ImpostoSenior.Domain.Entities.Ecd.Imposto
{
    public partial class ImpostoEcd
    {
        public static Constant Propriedade => new();

        public class Constant : PropriedadeConstante
        {
            public override IEnumerable<PropriedadeRegistro> ListOfProperties()
            => [new (nameof(DataLancamento), 1),
                    new (nameof(CodigoContabil), 2),
                    new (nameof(ValorOriginal), 3),
                    new (nameof(ValorCalculado), 4)];
        }
    }
}
