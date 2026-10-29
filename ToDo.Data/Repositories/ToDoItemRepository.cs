using ToDo.Core.Interfaces;
using ToDo.Core.Entities;

namespace ToDo.Data.Repositories;

public class ToDoItemRepository : GenericRepository<ToDoItem, Guid>, IToDoItemRepository
{
    public ToDoItemRepository(ApplicationDbContext context) : base(context)
    {
    }
}