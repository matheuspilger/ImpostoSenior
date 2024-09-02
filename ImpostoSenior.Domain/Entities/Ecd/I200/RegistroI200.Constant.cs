namespace ImpostoSenior.Domain.Entities.Ecd.I200
{
    public partial class RegistroI200
    {
        public static Constant Propriedade => new();

        public class Constant : PropriedadeConstante
        {
            public override IEnumerable<PropriedadeRegistro> ListOfProperties()
                => [new (nameof(Numero), 1),
                    new (nameof(Data), 2),
                    new (nameof(Valor), 3),
                    new (nameof(Indicador), 4),
                    new (nameof(DataExtemporaneo), 5)];
        }
    }
}
