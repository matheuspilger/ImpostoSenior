namespace ImpostoSenior.Domain.Entities.Ecd.C040
{
    public partial class RegistroC040
    {
        public static Constant Propriedade => new();

        public class Constant : PropriedadeConstante
        {
            public override IEnumerable<PropriedadeRegistro> ListOfProperties()
                => [new (nameof(Hash), 1),
                    new (nameof(DataInicial), 2),
                    new (nameof(DataFinal), 3),
                    new (nameof(Cnpj), 4)];
        }
    }
}
