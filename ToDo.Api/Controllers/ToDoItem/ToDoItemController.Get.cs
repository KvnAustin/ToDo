using Microsoft.AspNetCore.Mvc;

namespace ToDo.Api.Controllers.ToDoItem;

public partial class ToDoItemController
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var items = await _service.GetAllAsync();

        return Ok(items);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var item = await _service.GetByIdAsync(id);
        if (item is null)
            return NotFound();

        return Ok(item);
    }
}
