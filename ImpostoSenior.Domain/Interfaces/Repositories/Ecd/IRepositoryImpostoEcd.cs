using ImpostoSenior.Domain.Entities.Ecd.Imposto;
using ImpostoSenior.Domain.Interfaces.Filters;

namespace ImpostoSenior.Domain.Interfaces.Repositories.Ecd
{
    public interface IRepositoryImpostoEcd : IRepositoryBase<ImpostoEcd> 
    {
        Task<IEnumerable<ImpostoEcd>> GetMany(IFilterBase filterBase, CancellationToken cancellationToken);
    }
}
