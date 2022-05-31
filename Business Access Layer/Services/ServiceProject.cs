using Data_Access_Layer.Models;
using Data_Access_Layer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Repositories;

namespace Business_Access_Layer.Services
{
    public class ServiceProject : IServiceProject
    {
        private readonly ProjectRepository _repository;

        public ServiceProject(IProjectRepository repository)
        {
            _repository = (ProjectRepository)repository;
        }

        public async Task<Project> CreateProjectAsync(Project project)
        {
            try
            {
                if (project == null)
                {
                    throw new ArgumentNullException(nameof(project));
                }
                return await _repository.AddProjectAsync(project);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            try
            {
                return await _repository.GetAllProjectsAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Project> GetProjectById(int projectId)
        {
            try
            {
                if (projectId < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(projectId));
                }

                var result = await _repository.GetProjectAsync(projectId);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteProjectById(int projectId)
        {
            try
            {
                if (projectId < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(projectId));
                }
                _repository.DeleteProject(projectId);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
