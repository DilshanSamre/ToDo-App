using TodoApp.Api.DTOs;

namespace TodoApp.Api.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetRecentTasksAsync();
        Task<TaskDto> CreateTaskAsync(TaskCreateDto dto);
        Task<bool> MarkTaskAsDoneAsync(int id);
    }
}
