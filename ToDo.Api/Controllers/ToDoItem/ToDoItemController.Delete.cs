using Microsoft.AspNetCore.Mvc;

namespace ToDo.Api.Controllers.ToDoItem;

public partial class ToDoItemController
{

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted= await _service.DeleteAsync(id);
        if (deleted is false)
            return NotFound();

        return NoContent();
    }
}