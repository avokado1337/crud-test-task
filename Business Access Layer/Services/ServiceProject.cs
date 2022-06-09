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

        public async Task<Project> CreateProjectAsync(ProjectDto projectDto)
        {
            try
            {
                if (projectDto == null)
                {
                    throw new ArgumentNullException(nameof(projectDto));
                }
                return await _repository.AddProjectAsync(new Project() 
                {
                    Name = projectDto.Name,
                    Start = projectDto.Start,
                    Finish = projectDto.Finish,
                    Priority = projectDto.Priority,
                    Status = projectDto.Status
                });
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync()
        {
            try
            {
                var result = await _repository.GetAllProjectsAsync();

                var listOfProjectDtos = new List<ProjectDto>();

                foreach (var i in result)
                {
                    var tasksDto = new List<TaskDto>();
                    foreach (var j in i.Tasks)
                    {
                        if (i.Id == j.ProjectId)
                        {
                            tasksDto.Add(new TaskDto()
                            {
                                Id = j.Id,
                                Name = j.Name,
                                Status = j.Status,
                                Description = j.Description,
                                Priority = j.Priority,
                                ProjectId = j.ProjectId,
                                Project = j.Project.Name
                            });
                        }
                    }

                    listOfProjectDtos.Add(new ProjectDto()
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Start = i.Start,
                        Finish = i.Finish,
                        Priority = i.Priority,
                        Status = i.Status,
                        Tasks = tasksDto

                    });

                }

                return listOfProjectDtos.AsEnumerable();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProjectDto> GetProjectById(int projectId)
        {
            try
            {
                if (projectId < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(projectId));
                }

                var result = await _repository.GetProjectAsync(projectId);

                var tasksDto = new List<TaskDto>();
                
                foreach (var i in result.Tasks)
                {
                    tasksDto.Add(new TaskDto()
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

                return new ProjectDto() 
                {
                    Id = result.Id,
                    Name = result.Name,
                    Start = result.Start,
                    Finish = result.Finish,
                    Priority = result.Priority,
                    Status = result.Status,
                    Tasks = tasksDto
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Project> UpdateProjectAsync(int id, ProjectDto projectDto)
        {
            try
            {
                var result = await GetProjectById(id);

                var res = new Project()
                {
                    Name = projectDto.Name,
                    Start = projectDto.Start,
                    Finish = projectDto.Finish,
                    Status = projectDto.Status,
                    Priority = projectDto.Priority
                };


                if (result != null)
                {
                    return await _repository.UpdateProjectAsync(id, res);
                }
                throw new ArgumentNullException(nameof(projectDto));
            }
            catch(Exception)
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
