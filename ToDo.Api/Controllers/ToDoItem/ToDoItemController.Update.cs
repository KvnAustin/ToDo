using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Contracts.ToDoItem.Requests;
using ToDo.Core.Contracts.ToDoItem.Commands;

namespace ToDo.Api.Controllers.ToDoItem;

public partial class ToDoItemController
{

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateToDoItemRequest request)
    {
        var command = new UpdateToDoItemCommand
        {
            Title = request.Title,
            Description = request.Description,
            IsCompleted = request.IsCompleted,
            DueDate = request.DueDate,
            Priority = request.Priority
        };

        var updated = await _service.UpdateAsync(id, command);
        if (updated is false)
            return NotFound();

        return NoContent();
    }
}
