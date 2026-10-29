using ToDo.Core.Interfaces;
using ToDo.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ToDo.Data.Repositories;

public class ToDoItemRepository : GenericRepository<ToDoItem, Guid>, IToDoItemRepository
{
    public ToDoItemRepository(ApplicationDbContext context) : base(context)
    {
    }

    public override async Task<List<ToDoItem>> GetAllAsync()
    {
        return await _context.ToDoItems
            .OrderBy(toDoItem => toDoItem.Priority)
            .ThenBy(toDoItem => toDoItem.DueDate)
            .ThenBy(toDoItem => toDoItem.Title)
            .ToListAsync();
    }
}