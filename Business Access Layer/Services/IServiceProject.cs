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
        public Task<Project> CreateProjectAsync(Project project);
        public Task<IEnumerable<Project>> GetAllProjectsAsync();
        public Task<Project> GetProjectById(int projectId);
        public void DeleteProjectById(int projectId);
    }
}
