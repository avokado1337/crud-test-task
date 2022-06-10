using Business_Access_Layer.Services;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace akvelon_test_task_Presentation_Layer.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _service;
        public TaskController(ITaskService service)
        {
            _service = (TaskService)service;
        }

        [HttpPost("projects/{projectId}/tasks")]
        public async Task<Data_Access_Layer.Models.Task> AddTaskToProject(TaskDto taskDto, int projectId)
        {
            return await _service.AddTaskToProject(taskDto, projectId);
        }

        [HttpGet("projects/tasks")]
        public async Task<IEnumerable<TaskDto>> GetAllTasks()
        {
            return await _service.GetAllTasks();
        }

        [HttpGet("projects/{projectdId}/tasks/{taskId}")]
        public async Task<TaskDto> GetTaskFromProject(int projectId, int taskId)
        {
            return await _service.GetTaskFromProject(projectId, taskId);
        }

        [HttpPut("projects/{projectId}/tasks/{taskId}")]
        public async Task<Data_Access_Layer.Models.Task> UpgradeTask([FromBody] TaskDto task, int projectId, int taskId)
        {
            return await _service.UpgradeTask(task, projectId, taskId);
        }

        [HttpDelete("projects/{projectId}/tasks/{taskId}")]
        public void DeleteTask(int projectId, int taskId)
        {
            _service.DeleteTask(projectId, taskId);
        }
    }
}
