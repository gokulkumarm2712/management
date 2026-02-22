using management.Api.Common;
using Management.Api.Domain;

namespace Management.Api.Domain
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public TaskStatus Status { get; private set; }
        public TaskPriority Priority { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public TaskItem(string title, string? description, TaskPriority priority)
        {
            Title = title;
            Description = description;
            Priority = priority;
            Status = TaskStatus.Pending;
            CreatedAt = DateTime.UtcNow;
        }

        public Result UpdateStatus(TaskStatus newStatus)
        {
            if (Status == TaskStatus.Completed)
                return Result.Fail("Completed tasks cannot be updated");

            if (Status == TaskStatus.Pending && newStatus != TaskStatus.InProgress)
                return Result.Fail("Pending can only move to InProgress");

            if (Status == TaskStatus.InProgress && newStatus != TaskStatus.Completed)
                return Result.Fail("InProgress can only move to Completed");

            Status = newStatus;
            return Result.Ok();
        }
    }
}