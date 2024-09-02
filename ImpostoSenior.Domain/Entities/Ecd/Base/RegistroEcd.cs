using ImpostoSenior.Domain.Entities.Ecd.C040;
using ImpostoSenior.Domain.Entities.Ecd.I200;

namespace ImpostoSenior.Domain.Entities.Ecd.Base
{
    public partial class RegistroEcd
    {
        public RegistroC040 RegistroC040 { get; set; }
        public IEnumerable<RegistroI200> RegistrosI200 { get; set; }
    }
}
