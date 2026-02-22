using Management.Api.Domain;
using System.ComponentModel.DataAnnotations;
using Management.Api.Domain;

namespace Management.Api.Contracts
{
    public class CreateTaskRequest
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = "";

        public string? Description { get; set; }

        public TaskPriority Priority { get; set; } = TaskPriority.Medium;
    }
}