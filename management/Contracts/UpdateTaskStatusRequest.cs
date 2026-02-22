using System.ComponentModel.DataAnnotations;
using Management.Api.Domain;

namespace Management.Api.Contracts
{
    public class UpdateTaskStatusRequest
    {
        [Required]
        public Management.Api.Domain.TaskStatus Status { get; set; }
    }
}