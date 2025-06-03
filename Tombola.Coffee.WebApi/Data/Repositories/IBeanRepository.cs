using Tombola.Coffee.WebApi.Entities;

namespace Tombola.Coffee.WebApi.Data.Repositories;

public interface IBeanRepository
{
    Task<IEnumerable<Bean>> GetAllAsync();
    Task<Bean?> GetByIdAsync(string id);
    Task<Bean> GetBeanOfTheDayAsync();
    Task<Bean> CreateAsync(Bean bean);
    Task UpdateAsync(string id, Bean bean);
    Task DeleteAsync(string id);
}