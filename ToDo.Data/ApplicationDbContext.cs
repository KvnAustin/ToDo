using Microsoft.EntityFrameworkCore;
using ToDo.Core.Entities;

namespace ToDo.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<ToDoItem> ToDoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ToDoItem>()
            .HasQueryFilter(x => !x.IsDeleted);
    }
}
