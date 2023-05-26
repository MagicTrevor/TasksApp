using Microsoft.EntityFrameworkCore;
using TasksApp.Data;
using TasksApp.Data.Repositories;
using TasksApp.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

// Configure the Database connection.
builder.Services.AddDbContext<TasksAppContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// Register repositories
builder.Services.AddScoped<ITaskItemRepository, TaskItemRepository>();

// Register services

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("corsapp");

app.UseAuthorization();

app.MapControllers();

// Make sure database is up to date
using (var scope = app.Services.CreateScope())
{
    var tasksContext = scope.ServiceProvider.GetRequiredService<TasksAppContext>();
    tasksContext.Database.EnsureCreated();
}

app.Run();
