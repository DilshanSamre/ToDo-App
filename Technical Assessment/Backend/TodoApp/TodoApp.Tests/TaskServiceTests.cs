using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Services;
using TodoApp.DTOs;
using Xunit;

public class TaskServiceTests
{
	private async Task<AppDbContext> GetDbContext()
	{
		var options = new DbContextOptionsBuilder<AppDbContext>()
			.UseInMemoryDatabase(databaseName: "TodoTestDb")
			.Options;

		var dbContext = new AppDbContext(options);
		await dbContext.Database.EnsureCreatedAsync();
		return dbContext;
	}

	[Fact]
	public async Task CreateTask_Should_AddTaskToDatabase()
	{
		// Arrange
		var dbContext = await GetDbContext();
		var service = new TaskService(dbContext);

		var taskDto = new TaskCreateDto
		{
			Title = "Test Task",
			Description = "Testing"
		};

		// Act
		var result = await service.CreateTaskAsync(taskDto);

		// Assert
		Assert.NotNull(result);
		Assert.Equal("Test Task", result.Title);
	}
}
