using ImpostoSenior.Domain.Constants.Ecd;
using ImpostoSenior.Domain.Entities.Ecd.I200;
using ImpostoSenior.Domain.Factories;
using ImpostoSenior.Domain.Helpers;

namespace ImpostoSenior.Domain.Factories.Ecd
{
    public class RegistroFactoryI200 : RegistroFactoryBase<RegistroI200>
    {
        public static RegistroFactoryI200 Instance = new();

        public override IEnumerable<RegistroI200> Fabricate(IEnumerable<string> lines)
        {
            var linesToProcess = lines.Where(l => l.StartsWithAny(TipoRegistro.I200, TipoRegistro.I250));
            var registrosI200 = new List<RegistroI200>();

            RegistroI200? registroI200 = default;

            foreach (var lineToProcess in linesToProcess)
            {
                if (lineToProcess.StartsWithAny(TipoRegistro.I200))
                {
                    if (registroI200 is not null)
                        registrosI200.Add(registroI200);

                    registroI200 = RegistroI200.Builder.Build(lineToProcess);
                }
                else
                {
                    registroI200!.AddItem(lineToProcess);
                }
            }

            return registrosI200;
        }
    }
}
