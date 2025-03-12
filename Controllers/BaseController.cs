using Microsoft.AspNetCore.Mvc;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController<T> : ControllerBase where T : class
{
    protected readonly IBaseService<T> _service;

    public BaseController(IBaseService<T> service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null)
        {
            return NotFound();
        }
        return Ok(entity);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var entities = await _service.GetAllAsync();
        return Ok(entities);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] T entity)
    {
        if (entity == null)
        {
            return BadRequest();
        }

        await _service.AddAsync(entity);
        return CreatedAtAction(nameof(GetById), new { id = (entity as dynamic).Id }, entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] T entity)
    {
        if (entity == null || (entity as dynamic).Id != id)
        {
            return BadRequest();
        }

        var existingEntity = await _service.GetByIdAsync(id);
        if (existingEntity == null)
        {
            return NotFound();
        }

        if (entity == null)
        {
            return BadRequest();
        }

        await _service.UpdateAsync(entity);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var entity = await _service.GetByIdAsync(id);
        if (entity == null)
        {
            return NotFound();
        }

        await _service.DeleteAsync(entity);
        return NoContent();
    }
}