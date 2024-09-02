using ImpostoSenior.Domain.Entities.Ecd.C040;
using ImpostoSenior.Domain.Entities.Ecd.I200;

namespace ImpostoSenior.Domain.Entities.Ecd.Base
{
    public partial class RegistroEcd
    {
        public RegistroEcd(RegistroC040 registroC040,
            IEnumerable<RegistroI200> registrosI200)
        {
            RegistroC040 = registroC040;
            RegistrosI200 = registrosI200;
        }
    }
}