namespace TodoApp.Api.DTOs
{
    public class TaskCreateDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
    }
}
