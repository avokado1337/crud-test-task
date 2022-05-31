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
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        //Get project by id
        public async Task<Project> GetProjectAsync(int projectId)
        {
            return await _context.Projects.Include(x => x.Tasks).FirstOrDefaultAsync(x => x.Id == projectId);
        }

        //Get all projects
        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            //return await _context.Projects.ToListAsync();

            return await _context.Projects.Include(x => x.Tasks).ToListAsync();

        }

        //Add new project
        public async Task<Project> AddProjectAsync(Project project)
        {
            var result = await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        //Update project
        public async Task<Project> UpdateProjectAsync(Project project)
        {
            var result = await _context.Projects.FirstOrDefaultAsync(x => x.Id == project.Id);

            if (result != null)
            {
                result.Name = project.Name;
                result.Priority = project.Priority;
                result.Start = project.Start;
                result.Finish = project.Finish;
                result.Status = project.Status;
                result.Tasks = project.Tasks;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        //Delete Project
        public void DeleteProject(int projectId)
        {
            var result = _context.Projects.FirstOrDefault(x => x.Id == projectId);

            if (result != null)
            {
                _context.Projects.Remove(result);
                _context.SaveChanges();
            }
        }

        //Get all tasks from a project
        public async Task<IEnumerable<Models.Task>> GetAllTasksFromProject(int projectId)
        {
            var result = await _context.Projects.FirstOrDefaultAsync(x => x.Id == projectId);

            return result.Tasks.ToList();
        }
    }
}
