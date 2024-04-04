using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Data;

namespace ToDoListApp.ViewComponents;

public class ActivityLogViewComponent : ViewComponent
{
	private readonly ToDoDbContext _context;
	private readonly ILogger<ActivityLogViewComponent> _logger;

	public ActivityLogViewComponent(ToDoDbContext context,
		ILogger<ActivityLogViewComponent> logger)
	{
		_context = context;
		_logger = logger;
	}

	public async Task<IViewComponentResult> InvokeAsync(string taskId)
	{
		var activities = _context.Activities
			.Where(a => EF.Functions.Like(a.EntityId, taskId))
			.ToList();

		_logger.LogInformation($"{activities.Count} activities found");

		return View(activities);
	}
}
