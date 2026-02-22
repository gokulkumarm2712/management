using Management.Api.Contracts;
using Management.Api.Domain;
using DomainTaskStatus = Management.Api.Domain.TaskStatus;
using DomainTaskPriority = Management.Api.Domain.TaskPriority;
using management.Api.Common;
using Management.Api.Application;

namespace Management.Api.Application
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repo;

        public TaskService(ITaskRepository repo)
        {
            _repo = repo;
        }

        public TaskItem Create(CreateTaskRequest request)
        {
            var task = new TaskItem(request.Title, request.Description, request.Priority);
            return _repo.Add(task);
        }

        public IEnumerable<TaskItem> GetAll(DomainTaskStatus? status, DomainTaskPriority? priority)
        {
            var tasks = _repo.GetAll();

            if (status.HasValue)
                tasks = tasks.Where(t => t.Status == status.Value);

            if (priority.HasValue)
                tasks = tasks.Where(t => t.Priority == priority.Value);

            return tasks.OrderByDescending(t => t.Priority);
        }

        public TaskItem? GetById(int id)
        {
            return _repo.GetById(id);
        }

        public Result UpdateStatus(int id, DomainTaskStatus status)
        {
            var task = _repo.GetById(id);
            if (task == null)
                return Result.Fail("Task not found");

            var result = task.UpdateStatus(status);
            if (!result.Success)
                return result;

            _repo.Update(task);
            return Result.Ok();
        }
    }
}