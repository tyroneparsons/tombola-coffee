using Tombola.Coffee.WebApi.Data.Repositories;
using Tombola.Coffee.WebApi.Entities;
using Tombola.Coffee.WebApi.Models;

namespace Tombola.Coffee.WebApi.Services;

public class BeanService(IBeanRepository repository) : IBeanService
{
    public async Task<IEnumerable<BeanDto>> GetAllBeansAsync()
    {
        var beans = await repository.GetAllAsync();
        return beans.Select(b => new BeanDto
        {
            Id = b.Id,
            Name = b.Name,
            Description = b.Description,
            Cost = b.Cost,
            Colour = b.Colour,
            Country = b.Country,
            Image = b.Image
        });
    }

    public async Task<BeanDto?> GetBeanByIdAsync(string id)
    {
        var bean = await repository.GetByIdAsync(id);
        if (bean == null) return null;
        
        return new BeanDto
        {
            Id = bean.Id,
            Name = bean.Name,
            Description = bean.Description,
            Cost = bean.Cost,
            Colour = bean.Colour,
            Country = bean.Country,
            Image = bean.Image
        };
    }

    public async Task<BeanDto> GetBeanOfTheDayAsync()
    {
        var bean = await repository.GetBeanOfTheDayAsync();
        return new BeanDto
        {
            Id = bean.Id,
            Name = bean.Name,
            Description = bean.Description,
            Cost = bean.Cost,
            Colour = bean.Colour,
            Country = bean.Country,
            Image = bean.Image
        };
    }

    public async Task<BeanDto> CreateBeanAsync(Bean bean)
    {
        var createdBean = await repository.CreateAsync(bean);
        return new BeanDto
        {
            Id = createdBean.Id,
            Name = createdBean.Name,
            Description = createdBean.Description,
            Cost = createdBean.Cost,
            Colour = createdBean.Colour,
            Country = createdBean.Country,
            Image = createdBean.Image
        };
    }

    public async Task UpdateBeanAsync(string id, Bean bean)
    {
        await repository.UpdateAsync(id, bean);
    }

    public async Task DeleteBeanAsync(string id)
    {
        await repository.DeleteAsync(id);
    }
}