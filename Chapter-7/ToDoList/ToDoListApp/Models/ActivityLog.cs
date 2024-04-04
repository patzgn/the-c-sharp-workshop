namespace ToDoListApp.Models;

public class ActivityLog
{
	public Guid Id { get; set; }

	public string EntityId { get; set; }

	public DateTime Timestamp { get; set; }

	public string Property { get; set; }

	public string OldValue { get; set; }

	public string NewValue { get; set; }
}
