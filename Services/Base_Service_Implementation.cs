using Microsoft.EntityFrameworkCore;
using trekdle.Models.DB_Models;
using trekdle.DB_Context;

namespace trekdle.Services;
public class Base_Service<T>: IBaseService<T> where T : class, IEntity
{   
    private readonly DBContext _context; 
    private readonly DbSet<T> _dbSet;
    public Base_Service(DBContext context){
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllItemsAsync()
    {
        return await _dbSet.ToListAsync();
    }
    public async Task<T?> GetItemByIdAsync(long id)
    {
        return await _dbSet.FindAsync(id);
    }
    public async virtual Task CreateItemAsync(T item)
    {
        await _dbSet.AddAsync(item);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateItemAsync(T item)
    {
        _dbSet.Update(item);
        await _context.SaveChangesAsync();
        
    }
    public async Task DeleteItemAsync(long id)
    {
        var entity = await GetItemByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new KeyNotFoundException("Item not found");
        }
    }
}