namespace ProjectRenan.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Create(TEntity model);
        bool Update(TEntity entity);
        bool Delete(TEntity model);
    }
}
