using System.ComponentModel.DataAnnotations;

namespace ToDo.Api.Contracts.ToDoItem.Requests;

public class CreateToDoItemRequest
{
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Title { get; set; } = string.Empty;

    [StringLength(2000)]
    public string? Description { get; set; }
    
    [Required]
    public DateTime DueDate { get; set; }

    [Range(1, 3)]
    public int Priority { get; set; }
}