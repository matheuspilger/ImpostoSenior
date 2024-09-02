using ImpostoSenior.Domain.Entities.Ecd.C040;
using ImpostoSenior.Domain.Entities.Ecd.I200;

namespace ImpostoSenior.Domain.Entities.Ecd.Base
{
    public partial class RegistroEcd
    {
        public static class Builder
        {
            public static RegistroEcd Build(RegistroC040 registroC040, IEnumerable<RegistroI200> registrosL200) => new(registroC040, registrosL200);
        }
    }
}
