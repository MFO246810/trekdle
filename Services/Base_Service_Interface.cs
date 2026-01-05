using System.Collections.Generic;
using System.Threading.Tasks;
using trekdle.Models.DB_Models;

namespace trekdle.Services;
// The contract for your business logic
public interface IBaseService<T> where T : class, IEntity
{
    Task<IEnumerable<T>> GetAllItemsAsync();
    Task<T?> GetItemByIdAsync(long id);
    Task CreateItemAsync(T item);
    Task UpdateItemAsync(T item);
    Task DeleteItemAsync(long id);
}