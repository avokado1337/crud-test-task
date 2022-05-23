using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_Access_Layer.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Finish = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Finish", "Name", "Priority", "Start", "Status" },
                values: new object[] { 1, new DateTime(2022, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project #1", 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Finish", "Name", "Priority", "Start", "Status" },
                values: new object[] { 2, new DateTime(2022, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project #2", 9, new DateTime(2022, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "NotStarted" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "Name", "Priority", "ProjectId", "Status" },
                values: new object[] { 1, "This is a task that belongs to project #1", "Task #1", 1, 1, "InProgress" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "Name", "Priority", "ProjectId", "Status" },
                values: new object[] { 2, "This is a task that belongs to project #1", "Task #2", 2, 1, "ToDo" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "Name", "Priority", "ProjectId", "Status" },
                values: new object[] { 3, "This is a task that belongs to project #2", "Task #1", 1, 2, "ToDo" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
