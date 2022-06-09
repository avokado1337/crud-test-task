using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Access_Layer.Services
{
    public interface IServiceProject
    {
        public Task<Project> CreateProjectAsync(ProjectDto projectDto);
        public Task<IEnumerable<ProjectDto>> GetAllProjectsAsync();
        public Task<ProjectDto> GetProjectById(int projectId);
        public Task<Project> UpdateProjectAsync(int id, ProjectDto projectDto);
        public void DeleteProjectById(int projectId);
    }
}
