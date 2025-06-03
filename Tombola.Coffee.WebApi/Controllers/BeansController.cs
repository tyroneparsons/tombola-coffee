using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tombola.Coffee.WebApi.Data;
using Tombola.Coffee.WebApi.Entities;

namespace Tombola.Coffee.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BeansController(ILogger<BeansController> logger, AppDbContext dbContext) : ControllerBase
{
    private readonly ILogger<BeansController> _logger = logger;

    [HttpGet(Name = "GetBeans")]
    public async Task<ActionResult<IEnumerable<Bean>>> Get()
    {
        return await dbContext.Beans.ToListAsync();
    }

    [HttpGet("{id}", Name = "GetBeanById")]
    public async Task<ActionResult<Bean>> GetById(string id)
    {
        var bean = await dbContext.Beans.FindAsync(id);

        if (bean == null)
        {
            return NotFound();
        }

        return bean;
    }

    [HttpPost(Name = "CreateBean")]
    public async Task<ActionResult<Bean>> Create(Bean bean)
    {
        if (dbContext.Beans.Any(b => b.Id == bean.Id))
        {
            return Conflict();
        }
        
        dbContext.Beans.Add(bean);

        await dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = bean.Id }, bean);
    }

    [HttpPut("{id}", Name = "UpdateBean")]
    public async Task<IActionResult> Update(string id, Bean bean)
    {
        if (!dbContext.Beans.Any(b => b.Id == id))
        {
            return NotFound();
        }

        dbContext.Beans.Update(bean);

        await dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteBean")]
    public async Task<IActionResult> Delete(string id)
    {
        var bean = await dbContext.Beans.FindAsync(id);

        if (bean == null)
        {
            return NotFound();
        }

        dbContext.Beans.Remove(bean);

        await dbContext.SaveChangesAsync();

        return NoContent();
    }
}