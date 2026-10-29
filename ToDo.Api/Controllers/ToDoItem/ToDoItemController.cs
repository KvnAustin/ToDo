using Microsoft.AspNetCore.Mvc;
using ToDo.Core.Interfaces;

namespace ToDo.Api.Controllers.ToDoItem;

[ApiController]
[Route("[controller]")]
public partial class ToDoItemController : ControllerBase
{
    private readonly IToDoItem _service;

    public ToDoItemController(IToDoItem service)
    {
        _service = service;
    }
}
