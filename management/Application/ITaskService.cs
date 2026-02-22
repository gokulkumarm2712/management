using management.Api.Common;
using Management.Api.Contracts;
using Management.Api.Domain;

namespace Management.Api.Application
{
    public interface ITaskService
    {
        TaskItem Create(CreateTaskRequest request);
        IEnumerable<TaskItem> GetAll(Domain.TaskStatus? status, TaskPriority? priority);
        TaskItem? GetById(int id);
        Result UpdateStatus(int id, Domain.TaskStatus status);
    }
}