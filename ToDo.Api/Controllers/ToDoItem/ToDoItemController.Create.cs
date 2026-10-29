using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Contracts.ToDoItem.Requests;
using ToDo.Core.Contracts.ToDoItem.Commands;

namespace ToDo.Api.Controllers.ToDoItem;

public partial class ToDoItemController
{

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateToDoItemRequest request)
    {
        var command = new CreateToDoItemCommand
        {
            Title = request.Title,
            Description = request.Description,
            DueDate = request.DueDate,
            Priority = request.Priority
        };

        var item = await _service.CreateAsync(command);

        return StatusCode(StatusCodes.Status201Created, item);
    }
}
