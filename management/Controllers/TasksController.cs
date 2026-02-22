using Management.Api.Application;
using Management.Api.Contracts;
using Management.Api.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace TaskManagement.Api.Controllers
{
    [ApiController]
    [Route("tasks")]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateTaskRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = _service.Create(request);

            return CreatedAtAction(nameof(GetById), new { id = task.Id }, Map(task));
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] Management.Api.Domain.TaskStatus? status, [FromQuery] TaskPriority? priority)
        {
            var tasks = _service.GetAll(status, priority).Select(Map);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var task = _service.GetById(id);
            if (task == null)
                return NotFound();

            return Ok(Map(task));
        }

        [HttpPut("{id}/status")]
        public IActionResult UpdateStatus(int id, [FromBody] UpdateTaskStatusRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _service.UpdateStatus(id, request.Status);

            if (!result.Success)
                return BadRequest(new { message = result.Error });

            return NoContent();
        }

        private static TaskResponse Map(TaskItem task)
        {
            return new TaskResponse
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                Priority = task.Priority,
                CreatedAt = task.CreatedAt
            };
        }
    }
}