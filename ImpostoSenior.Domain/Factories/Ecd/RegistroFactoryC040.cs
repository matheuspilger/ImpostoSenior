using ImpostoSenior.Domain.Constants.Ecd;
using ImpostoSenior.Domain.Entities.Ecd.C040;
using ImpostoSenior.Domain.Factories;
using ImpostoSenior.Domain.Helpers;

namespace ImpostoSenior.Domain.Factories.Ecd
{
    public class RegistroFactoryC040 : RegistroFactoryBase<RegistroC040>
    {
        public static RegistroFactoryC040 Instance = new();

        public override IEnumerable<RegistroC040> Fabricate(IEnumerable<string> lines)
        {
            var lineToProcess = lines.First(l => l.StartsWithAny(TipoRegistro.C040));
            return [RegistroC040.Builder.Build(lineToProcess)];
        }
    }
}
