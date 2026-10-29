namespace ToDo.Core.Contracts.ToDoItem.Commands;

public class UpdateToDoItemCommand
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
    public int Priority { get; set; }
}
