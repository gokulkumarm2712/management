using Management.Api.Domain;
using Management.Api.Domain;

namespace Management.Api.Application
{
    public interface ITaskRepository
    {
        TaskItem Add(TaskItem task);
        TaskItem? GetById(int id);
        IEnumerable<TaskItem> GetAll();
        void Update(TaskItem task);
    }
}