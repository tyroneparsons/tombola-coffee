using Tombola.Coffee.WebApi.Entities;
using Tombola.Coffee.WebApi.Models;

namespace Tombola.Coffee.WebApi.Services;

public interface IBeanService
{
    Task<IEnumerable<BeanDto>> GetAllBeansAsync();
    Task<BeanDto?> GetBeanByIdAsync(string id);
    Task<BeanDto> GetBeanOfTheDayAsync();
    Task<BeanDto> CreateBeanAsync(Bean bean);
    Task UpdateBeanAsync(string id, Bean bean);
    Task DeleteBeanAsync(string id);
}