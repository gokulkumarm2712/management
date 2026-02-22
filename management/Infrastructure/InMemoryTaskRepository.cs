using Management.Api.Application;
using Management.Api.Domain;


namespace Management.Api.Infrastructure
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<TaskItem> _tasks = new();
        private int _id = 1;

        public TaskItem Add(TaskItem task)
        {
            task.Id = _id++;
            _tasks.Add(task);
            return task;
        }

        public TaskItem? GetById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<TaskItem> GetAll()
        {
            return _tasks;
        }

        public void Update(TaskItem task)
        {
        }
    }
}