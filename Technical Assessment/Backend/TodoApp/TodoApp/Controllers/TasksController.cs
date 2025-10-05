using Microsoft.AspNetCore.Mvc;
using TodoApp.Api.DTOs;
using TodoApp.Api.Services;

namespace TodoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecentTasks()
        {
            var tasks = await _taskService.GetRecentTasksAsync();
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskCreateDto dto)
        {
            var task = await _taskService.CreateTaskAsync(dto);
            return CreatedAtAction(nameof(GetRecentTasks), new { id = task.Id }, task);
        }

        [HttpPatch("{id}/done")]
        public async Task<IActionResult> MarkAsDone(int id)
        {
            var result = await _taskService.MarkTaskAsDoneAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
