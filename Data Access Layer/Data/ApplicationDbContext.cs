using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }


        public DbSet<Project> Projects { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Conversing enums for them to be in database
            modelBuilder
                .Entity<Project>()
                .Property(x => x.Status)
                .HasConversion(v => v.ToString(),
                v => (ProjectStatus)Enum.Parse(typeof(ProjectStatus), v));

            modelBuilder
                .Entity<Models.Task>()
                .Property(x => x.Status)
                .HasConversion(v => v.ToString(),
                v => (Models.TaskStatus)Enum.Parse(typeof(Models.TaskStatus), v));


            //Seeding with the initial data
            //One project, two tasks
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Name = "Project #1",
                    Start = new DateTime(2022, 01, 01),
                    Finish = new DateTime(2022, 05, 31),
                    Priority = 1,
                    Status = ProjectStatus.Active
                });

            modelBuilder.Entity<Models.Task>().HasData(
                new Models.Task
                {
                    Id = 1,
                    Name = "Task #1",
                    Description = "This is a task that belongs to project #1",
                    Priority = 1,
                    Status = Models.TaskStatus.InProgress,
                    ProjectId = 1
                });

            modelBuilder.Entity<Models.Task>().HasData(
                new Models.Task
                {
                    Id = 2,
                    Name = "Task #2",
                    Description = "This is a task that belongs to project #1",
                    Priority = 2,
                    Status = Models.TaskStatus.ToDo,
                    ProjectId = 1
                });

            //One project, one task
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 2,
                    Name = "Project #2",
                    Start = new DateTime(2022, 05, 31),
                    Finish = new DateTime(2022, 08, 31),
                    Priority = 9,
                    Status = ProjectStatus.NotStarted
                });

            modelBuilder.Entity<Models.Task>().HasData(
                new Models.Task
                {
                    Id = 3,
                    Name = "Task #1",
                    Description = "This is a task that belongs to project #2",
                    Priority = 1,
                    Status = Models.TaskStatus.ToDo,
                    ProjectId = 2
                });
        }
    }
}
