using Management.Api.Domain;
using Management.Api.Domain;

namespace Management.Api.Contracts
{
    public class TaskResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public Management.Api.Domain.TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}