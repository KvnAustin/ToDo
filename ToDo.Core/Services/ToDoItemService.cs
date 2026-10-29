using ToDo.Core.Contracts.ToDoItem.Commands;
using ToDo.Core.Contracts.ToDoItem.Results;
using ToDo.Core.Entities;
using ToDo.Core.Interfaces;

namespace ToDo.Core.Services;

public class ToDoItemService : IToDoItem
{
    private readonly IToDoItemRepository _repository;

    public ToDoItemService(IToDoItemRepository repository)  
    {
        _repository = repository;
    }

    public async Task<List<ToDoItemResult>> GetAllAsync()
    {
        var items = await _repository.GetAllAsync();

        return items
            .Select(ToResult)
            .ToList();
    }

    public async Task<ToDoItemResult?> GetByIdAsync(Guid id)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item is null)
            return null;

        return ToResult(item);
    }

    public async Task<ToDoItemResult> CreateAsync(CreateToDoItemCommand command)
    {
        var item = new ToDoItem
        {
            Title = command.Title,
            Description = command.Description,
            IsCompleted = false,
            DueDate = command.DueDate,
            Priority = command.Priority
        };

        var createdItem = await _repository.CreateAsync(item);

        return ToResult(createdItem);
    }

    public async Task<bool> UpdateAsync(Guid id, UpdateToDoItemCommand command)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item is null)
            return false;

        item.Title = command.Title;
        item.Description = command.Description;
        item.IsCompleted = command.IsCompleted;
        item.DueDate = command.DueDate;
        item.Priority = command.Priority;

        await _repository.UpdateAsync(item);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item is null)
            return false;
        
        await _repository.DeleteAsync(id);

        return true;
    }

    #region [ Helper Methods ]
    private static ToDoItemResult ToResult(ToDoItem item)
    {
        return new ToDoItemResult
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description,
            IsCompleted = item.IsCompleted,
            DueDate = item.DueDate,
            Priority = item.Priority
        };
    }
    #endregion
}