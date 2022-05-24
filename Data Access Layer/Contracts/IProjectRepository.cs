using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Contracts
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectAsync(int projectId);
        Task<Project> AddProjectAsync(Project project);
        Task<Project> UpdateProjectAsync(Project project);
        void DeleteProject(int projectId);
        Task<IEnumerable<Models.Task>> GetAllTasksFromProject(int projectId);
    }
}
