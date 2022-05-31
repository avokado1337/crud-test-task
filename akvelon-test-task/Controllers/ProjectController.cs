//using Business_Access_Layer.Services;
using Business_Access_Layer.Services;
using Data_Access_Layer.Contracts;
using Data_Access_Layer.Models;
using Data_Access_Layer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace akvelon_test_task_Presentation_Layer.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ServiceProject _service;
        public ProjectController(IServiceProject service)
        {
            _service = (ServiceProject)service;
        }

        [HttpGet("projects")]
        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _service.GetAllProjectsAsync();
        }

        [HttpPost("projects")]
        public async Task<Project> CreateProjectAsync(Project project)
        {
            return await _service.CreateProjectAsync(project);
        }

        [HttpGet("projects/{id}")]
        public async Task<Project> GetProjectById(int id)
        {
            return await _service.GetProjectById(id);
        }

        [HttpDelete("projects{id}")]
        public void DeleteProjectById(int id)
        {
            _service.DeleteProjectById(id);
        }

    }
}
