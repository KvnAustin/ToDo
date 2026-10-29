using ToDo.Core.Contracts.ToDoItem.Commands;
using ToDo.Core.Contracts.ToDoItem.Results;

namespace ToDo.Core.Interfaces;

public interface IToDoItem
{
    public Task<List<ToDoItemResult>> GetAllAsync();
    public Task<ToDoItemResult?> GetByIdAsync(Guid id);
    public Task<ToDoItemResult> CreateAsync(CreateToDoItemCommand toDoItem);
    public Task<bool> UpdateAsync(Guid id, UpdateToDoItemCommand toDoItem);
    public Task<bool> DeleteAsync(Guid id);
}
