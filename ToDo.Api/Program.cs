using Microsoft.EntityFrameworkCore;
using ToDo.Core.Interfaces;
using ToDo.Core.Services;
using ToDo.Data;
using ToDo.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IToDoItemRepository, ToDoItemRepository>();
builder.Services.AddScoped<IToDoItem, ToDoItemService>();

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
