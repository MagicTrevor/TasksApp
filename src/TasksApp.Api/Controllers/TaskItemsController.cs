using Microsoft.AspNetCore.Mvc;
using TasksApp.Domain.Entities;
using TasksApp.Domain.Services;

namespace TasksApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskItemsController : ControllerBase
{
    private readonly ITaskItemService _service;

    public TaskItemsController(ITaskItemService service)
    {
        _service = service;
    }

    [HttpGet("{id:Guid}")]
    public async Task<TaskItem?> Get(Guid id) => await _service.GetAsync(id);

    [HttpGet]
    public async Task<IEnumerable<TaskItem>> GetAll() => await _service.GetAllAsync();

    [HttpPost]
    public async Task<TaskItem> Create(TaskItem itemToCreate)
    {
        return await _service.CreateAsync(itemToCreate);
    }

    [HttpPost("{id:Guid}/description")]
    public async Task<TaskItem?> UpdateDescription(Guid id, string description)
    {
        return await _service.UpdateDescription(id, description);
    }

    [HttpPost("{id:Guid}/complete")]
    public async Task<TaskItem?> MarkComplete(Guid id)
    {
        return await _service.MarkComplete(id);
    }
}