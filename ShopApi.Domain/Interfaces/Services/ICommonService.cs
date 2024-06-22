namespace ShopApi.Domain.Interfaces.Services
{
    public interface ICommonService<T,Id>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Id id);
        Task<T> CreateAsync(T model);
        Task<T> CreateMultiple(List<T> listModel);
        Task<T> UpdateAsync(T model);
        Task<T> DeleteAsync(Id id);
    }
}
