using Microsoft.EntityFrameworkCore;
using Tombola.Coffee.WebApi.Data;
using Tombola.Coffee.WebApi.Entities;
using Tombola.Coffee.WebApi.Models;

namespace Tombola.Coffee.WebApi.Services;

public class BeanService(AppDbContext dbContext, ILogger<BeanService> logger) : IBeanService
{
    private static BeanDto MapToDto(Bean bean) => new BeanDto
    {
        Id = bean.Id,
        Name = bean.Name,
        Description = bean.Description,
        Cost = bean.Cost,
        Colour = bean.Colour,
        Country = bean.Country,
        Image = bean.Image
    };

    public async Task<IEnumerable<BeanDto>> GetAllBeansAsync()
    {
        var beans = await dbContext.Beans.ToListAsync();
        return beans.Select(MapToDto);
    }

    public async Task<BeanDto?> GetBeanByIdAsync(string id)
    {
        var bean = await dbContext.Beans.FindAsync(id);
        return bean == null ? null : MapToDto(bean);
    }

    public async Task<BeanDto> GetBeanOfTheDayAsync()
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        // Check if we already have a bean for today
        var beanOfTheDay = await dbContext.BeanOfTheDays
            .Include(b => b.Bean)
            .FirstOrDefaultAsync(b => b.Date == today);

        if (beanOfTheDay != null)
        {
            return MapToDto(beanOfTheDay.Bean);
        }

        var allBeans = await dbContext.Beans.ToListAsync();

        if (allBeans.Count == 0)
        {
            throw new InvalidOperationException("No beans available to select from");
        }

        var yesterday = today.AddDays(-1);
        var yesterdaysBeanOfTheDay = await dbContext.BeanOfTheDays
            .FirstOrDefaultAsync(b => b.Date == yesterday);

        var eligibleBeans = yesterdaysBeanOfTheDay != null
            ? allBeans.Where(b => b.Id != yesterdaysBeanOfTheDay.BeanId).ToList()
            : allBeans;

        if (eligibleBeans.Count == 0)
        {
            eligibleBeans = allBeans;
            logger.LogWarning("Only one bean available - will have to reuse yesterday's bean");
        }

        var random = new Random();
        var randomBean = eligibleBeans[random.Next(eligibleBeans.Count)];

        var newBeanOfTheDay = new BeanOfTheDay
        {
            Id = Guid.NewGuid(),
            Date = today,
            BeanId = randomBean.Id,
            Bean = randomBean
        };

        dbContext.BeanOfTheDays.Add(newBeanOfTheDay);
        await dbContext.SaveChangesAsync();

        return MapToDto(randomBean);
    }

    public async Task<BeanDto> CreateBeanAsync(Bean bean)
    {
        if (await dbContext.Beans.AnyAsync(b => b.Id == bean.Id))
        {
            throw new InvalidOperationException($"Bean with ID {bean.Id} already exists");
        }

        dbContext.Beans.Add(bean);
        await dbContext.SaveChangesAsync();

        return MapToDto(bean);
    }

    public async Task UpdateBeanAsync(string id, Bean bean)
    {
        if (!await dbContext.Beans.AnyAsync(b => b.Id == id))
        {
            throw new KeyNotFoundException($"Bean with ID {id} not found");
        }

        dbContext.Beans.Update(bean);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteBeanAsync(string id)
    {
        var bean = await dbContext.Beans.FindAsync(id);

        if (bean == null)
        {
            throw new KeyNotFoundException($"Bean with ID {id} not found");
        }

        dbContext.Beans.Remove(bean);
        await dbContext.SaveChangesAsync();
    }
}