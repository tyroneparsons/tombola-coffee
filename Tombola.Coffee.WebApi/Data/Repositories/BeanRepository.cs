using Microsoft.EntityFrameworkCore;
using Tombola.Coffee.WebApi.Data;
using Tombola.Coffee.WebApi.Entities;

namespace Tombola.Coffee.WebApi.Data.Repositories;

public class BeanRepository(AppDbContext context) : IBeanRepository
{
    public async Task<IEnumerable<Bean>> GetAllAsync()
    {
        return await context.Beans.ToListAsync();
    }

    public async Task<Bean?> GetByIdAsync(string id)
    {
        return await context.Beans.FindAsync(id);
    }

    public async Task<Bean> GetBeanOfTheDayAsync()
    {
        var beanOfTheDay = await context.BeanOfTheDays
            .OrderByDescending(b => b.Date)
            .FirstOrDefaultAsync();

        if (beanOfTheDay != null)
        {
            return await context.Beans.FindAsync(beanOfTheDay.BeanId) 
                ?? throw new InvalidOperationException("Bean of the day not found");
        }

        return await context.Beans
            .OrderBy(r => Guid.NewGuid())
            .FirstAsync();
    }

    public async Task<Bean> CreateAsync(Bean bean)
    {
        var existingBean = await context.Beans.FindAsync(bean.Id);
        if (existingBean != null)
        {
            throw new InvalidOperationException($"Bean with ID {bean.Id} already exists");
        }

        context.Beans.Add(bean);
        await context.SaveChangesAsync();
        return bean;
    }

    public async Task UpdateAsync(string id, Bean bean)
    {
        if (id != bean.Id)
        {
            throw new ArgumentException("Id mismatch", nameof(id));
        }

        var existingBean = await context.Beans.FindAsync(id);
        if (existingBean == null)
        {
            throw new KeyNotFoundException($"Bean with ID {id} not found");
        }

        context.Entry(existingBean).CurrentValues.SetValues(bean);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var bean = await context.Beans.FindAsync(id);
        if (bean == null)
        {
            throw new KeyNotFoundException($"Bean with ID {id} not found");
        }

        context.Beans.Remove(bean);
        await context.SaveChangesAsync();
    }
}