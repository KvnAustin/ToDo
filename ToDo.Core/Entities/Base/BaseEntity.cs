namespace ToDo.Core.Entities.Base;

public class BaseEntity<TId> where TId : struct
{
    public TId Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOn { get; set; }
}
