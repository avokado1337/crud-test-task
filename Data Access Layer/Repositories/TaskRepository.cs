using Data_Access_Layer.Contracts;
using Data_Access_Layer.Data;
using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Task> AddTaskToProject(Models.Task task, int projectId)
        {
            var result = await _context.Projects.FirstOrDefaultAsync(x => x.Id == projectId);

            var createdTask = new Models.Task
            {
                Name = task.Name,
                Description = task.Description,
                Priority = task.Priority,
                Status = task.Status,
                ProjectId = projectId
            };

            if (result != null)
            {
                result.Tasks.Add(createdTask);
                return createdTask;
            }
            else
            {
                return null;
            }


        }

        public void DeleteTask(int projectId, int taskId)
        {
            var result = _context.Tasks.FirstOrDefault(x => x.ProjectId == projectId && x.Id == taskId);
            if (result != null)
            {
                _context.Tasks.Remove(result);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Models.Task>> GetAllTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Models.Task> GetTaskFromProject(int projectId, int taskId)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == projectId);
            if (project != null)
            {
                var result = project.Tasks.FirstOrDefault(x => x.Id == taskId);
                if (result != null)
                {
                    return result;
                }

                return null;
            }

            return null;
        }

        public async Task<Models.Task> UpgradeTask(Models.Task task, int projectId, int taskId)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Id == projectId);
            var taskIdentifier = await _context.Tasks.FirstOrDefaultAsync(e => e.Id == taskId);

            if (project != null && taskIdentifier != null)
            {
                var result = project.Tasks.FirstOrDefault(x => x.Id == taskId);
                if (result != null)
                {
                    result.Name = task.Name;
                    result.Priority = task.Priority;
                    result.ProjectId = task.ProjectId;
                    result.Status = task.Status;
                    result.Description = task.Description;
                    await _context.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            return null;
        }
    }
}
