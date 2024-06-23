namespace ShopApi.Domain.Interfaces.Interactors
{
    public interface ICommonInteractor<TEntity>
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> CreateAsync(TEntity entity);
        Task<bool> CreateMultipleAsync(List<TEntity> entitys);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> RemoveAsync(TEntity entity);
        Task<bool> SaveChangesAsync();
    }
}
