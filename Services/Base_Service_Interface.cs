using System.Collections.Generic;
using System.Threading.Tasks;

// The contract for your business logic
public interface IBaseService<T> where T : class
{
    Task<IEnumerable<T>> GetAllItemsAsync();
    Task<T?> GetItemByIdAsync(long id);
    Task<T> CreateItemAsync(T item);
    Task<T> UpdateItemAsync(long id, T item);
    Task DeleteItemAsync(long id);
}