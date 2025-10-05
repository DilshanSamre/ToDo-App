using Microsoft.EntityFrameworkCore;
using TodoApp.Api.Data;
using TodoApp.Api.DTOs;
using TodoApp.Api.Models;

namespace TodoApp.Api.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        // Get the 5 most recent tasks that are not completed
        public async Task<IEnumerable<TaskDto>> GetRecentTasksAsync()
        {
            return await _context.Tasks
                .Where(t => !t.IsCompleted)
                .OrderByDescending(t => t.CreatedAt)
                .Take(5)
                .Select(t => new TaskDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    IsCompleted = t.IsCompleted,
                    CreatedAt = t.CreatedAt
                })
                .ToListAsync();
        }

        // Create a new task
        public async Task<TaskDto> CreateTaskAsync(TaskCreateDto dto)
        {
            var task = new Models.TodoTask
            {
                Title = dto.Title,
                Description = dto.Description
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                CreatedAt = task.CreatedAt
            };
        }

        // Mark a task as completed
        public async Task<bool> MarkTaskAsDoneAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            task.IsCompleted = true;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
