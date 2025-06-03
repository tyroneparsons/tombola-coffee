using Microsoft.AspNetCore.Mvc;
using Tombola.Coffee.WebApi.Entities;
using Tombola.Coffee.WebApi.Models;
using Tombola.Coffee.WebApi.Services;

namespace Tombola.Coffee.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BeansController(IBeanService beanService, ILogger<BeansController> logger) : ControllerBase
{
    private readonly ILogger<BeansController> _logger = logger;

    [HttpGet(Name = "GetBeans")]
    public async Task<ActionResult<IEnumerable<BeanDto>>> Get()
    {
        var beans = await beanService.GetAllBeansAsync();
        return Ok(beans);
    }

    [HttpGet("{id}", Name = "GetBeanById")]
    public async Task<ActionResult<BeanDto>> GetById(string id)
    {
        var bean = await beanService.GetBeanByIdAsync(id);
        return bean == null ? NotFound() : Ok(bean);
    }

    [HttpGet("OfTheDay", Name = "GetBeanOfTheDay")]
    public async Task<ActionResult<BeanDto>> GetBeanOfTheDay()
    {
        try
        {
            var bean = await beanService.GetBeanOfTheDayAsync();
            return Ok(bean);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<BeanDto>>> Search([FromQuery] string query)
    {
        try
        {
            var results = await beanService.SearchBeansAsync(query);
            return Ok(results);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while searching beans");
            return StatusCode(500, "An error occurred while processing your request");
        }
    }

    [HttpPost(Name = "CreateBean")]
    public async Task<ActionResult<BeanDto>> Create(Bean bean)
    {
        try
        {
            var createdBean = await beanService.CreateBeanAsync(bean);
            return CreatedAtAction(nameof(GetById), new { id = createdBean.Id }, createdBean);
        }
        catch (InvalidOperationException)
        {
            return Conflict();
        }
    }

    [HttpPut("{id}", Name = "UpdateBean")]
    public async Task<IActionResult> Update(string id, Bean bean)
    {
        try
        {
            await beanService.UpdateBeanAsync(id, bean);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}", Name = "DeleteBean")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await beanService.DeleteBeanAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}