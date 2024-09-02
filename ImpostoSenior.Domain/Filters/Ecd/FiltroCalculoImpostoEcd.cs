using ImpostoSenior.Domain.Entities.Ecd.C040;
using LinqKit;
using System.Linq.Expressions;

namespace ImpostoSenior.Domain.Filters.Ecd
{
    public partial class FiltroCalculoImpostoEcd : FiltroBase<RegistroC040>
    {
        public FiltroCalculoImpostoEcd(DateTime dataInicial, DateTime dataFinal, string cnpj, string hash)
        {
            DataInicial = dataInicial;
            DataFinal = dataFinal;
            Cnpj = cnpj;
            Hash = hash;
        }

        public DateTime DataInicial { get; }
        public DateTime DataFinal { get; }
        public string Cnpj { get; } = default!;
        public string Hash { get; } = default!;

        public override Expression<Func<RegistroC040, bool>> GetFilter()
        {
            var filter = base.GetFilter();
            return filter.And(x => x.DataInicial == DataInicial &&
                x.DataFinal == DataFinal && x.Cnpj == Cnpj && x.Hash == Hash);
        }
    }
}
