using System.ComponentModel.DataAnnotations;
using ToDo.Core.Entities.Base;

namespace ToDo.Core.Entities;

public class ToDoItem : BaseEntity<Guid>
{
    [Required]
    [MaxLength(2000)]
    public string Title { get; set; } = string.Empty;
    
    [MaxLength(2000)]
    public string? Description { get; set; }
    
    public bool IsCompleted { get; set; }
    
    public DateTime DueDate { get; set; }

    [Range(1, 3)]
    public int Priority { get; set; }
}
