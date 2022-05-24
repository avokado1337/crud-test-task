//using Business_Access_Layer.Services;
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
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectRepository _repository;
        public ProjectController(IProjectRepository repository)
        {
            _repository = (ProjectRepository)repository;
        }
        [HttpGet("getall")]
        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _repository.GetAllProjectsAsync();
        }
    }
}
