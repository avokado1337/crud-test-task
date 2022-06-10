using Data_Access_Layer.Contracts;
using Data_Access_Layer.Repositories;
using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Models;

namespace Business_Access_Layer.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = (TaskRepository)repository;
        }

        public async Task<Data_Access_Layer.Models.Task> AddTaskToProject(TaskDto taskDto, int projectId)
        {
            try
            {
                if (projectId < 0)
                {
                    throw new ArgumentNullException();
                }

                var task = new Data_Access_Layer.Models.Task()
                {
                    Name = taskDto.Name,
                    Description = taskDto.Description,
                    Status = taskDto.Status,
                    Priority = taskDto.Priority,
                    ProjectId = projectId
                };

                return await _repository.AddTaskToProject(task, projectId);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void DeleteTask(int projectId, int taskId)
        {
            if (projectId < 0 || taskId < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            _repository.DeleteTask(projectId, taskId);
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasks()
        {
            var result = await _repository.GetAllTasks();

            var taskDtos = new List<TaskDto>();

            if (result != null)
            {
                foreach(var i in result)
                {   
                    taskDtos.Add(new TaskDto() 
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Status = i.Status,
                        Description = i.Description,
                        Priority = i.Priority,
                        ProjectId = i.ProjectId,
                        Project = i.Project.Name
                    });
                }
            }

            return taskDtos.AsEnumerable();
        }

        public async Task<TaskDto> GetTaskFromProject(int projectId, int taskId)
        {
            var result = await _repository.GetTaskFromProject(projectId, taskId);

            var taskDto = new TaskDto()
            {
                Name = result.Name,
                Status = result.Status,
                Description = result.Description,
                Priority = result.Priority,
                ProjectId = result.ProjectId,
                Project = result.Project.Name
            };

            return taskDto;
        }

        public async Task<Data_Access_Layer.Models.Task> UpgradeTask(TaskDto taskDto, int projectId, int taskId)
        {
            try
            {
                if (projectId < 0 || taskId < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (taskDto != null)
                {
                    var task = new Data_Access_Layer.Models.Task()
                    {
                        Name = taskDto.Name,
                        Status = taskDto.Status,
                        Description = taskDto.Description,
                        Priority = taskDto.Priority,
                        ProjectId = taskDto.ProjectId,
                    };
                    return await _repository.UpgradeTask(task, projectId, taskId);
                }
                else
                {
                    throw new ArgumentNullException();
                }
                
            }
            catch(Exception)
            {
                throw;
            }

        }
    }
}
