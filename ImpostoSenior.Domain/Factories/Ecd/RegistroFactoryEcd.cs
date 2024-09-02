using ImpostoSenior.Domain.Entities.Ecd.Base;
using ImpostoSenior.Domain.Factories;

namespace ImpostoSenior.Domain.Factories.Ecd
{
    public class RegistroFactoryEcd : RegistroFactoryBase<RegistroEcd>
    {
        public static RegistroFactoryEcd Instance = new();

        public override IEnumerable<RegistroEcd> Fabricate(IEnumerable<string> lines)
        {
            var registroC040 = RegistroFactoryC040.Instance.Fabricate(lines).First();
            var registrosI200 = RegistroFactoryI200.Instance.Fabricate(lines);
            var registroEcd = RegistroEcd.Builder.Build(registroC040, registrosI200);
            return [registroEcd];
        }
    }
}
