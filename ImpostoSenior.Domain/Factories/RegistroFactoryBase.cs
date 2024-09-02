namespace ImpostoSenior.Domain.Factories
{
    public abstract class RegistroFactoryBase<TEntity>
    {
        public abstract IEnumerable<TEntity> Fabricate(IEnumerable<string> lines);
    }
}
