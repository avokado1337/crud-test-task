using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Models;
using Task = Data_Access_Layer.Models.Task;

namespace Business_Access_Layer.Services
{
    public interface ITaskService
    {
        public Task<Task> AddTaskToProject(TaskDto taskDto, int projectId);
        public Task<IEnumerable<TaskDto>> GetAllTasks();
        public Task<TaskDto> GetTaskFromProject(int projectId, int taskId);
        public Task<Task> UpgradeTask(TaskDto task, int projectId, int taskId);
        public void DeleteTask(int projectId, int taskId);
    }
}
