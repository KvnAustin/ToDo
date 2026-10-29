using ToDo.Core.Entities;

namespace ToDo.Core.Interfaces;

public interface IToDoItemRepository
{
    Task<List<ToDoItem>> GetAllAsync();
    Task<ToDoItem?> GetByIdAsync(Guid id);
    Task<ToDoItem> CreateAsync(ToDoItem item);
    Task UpdateAsync(ToDoItem item);
    Task DeleteAsync(Guid id);
}