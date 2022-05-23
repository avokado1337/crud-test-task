using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Contracts
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Models.Task>> GetAllTasks();
        Task<Models.Task> GetTaskFromProject(int projectId, int taskId);
        Task<Models.Task> AddTaskToProject(Models.Task task, int projectId);
        Task<Project> UpgradeTask(Models.Task task, int projectId);
        void DeleteTask(int projectId, int taskId);

    }
}
