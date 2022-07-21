using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LearningDiaryAadaV2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EstimatedTimeToMaster = table.Column<int>(nullable: true),
                    TimeSpent = table.Column<int>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    StartLearningDate = table.Column<DateTime>(nullable: true),
                    InProgress = table.Column<bool>(nullable: true),
                    CompletionDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskInTopic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Deadline = table.Column<DateTime>(nullable: true),
                    Priority = table.Column<string>(nullable: true),
                    Done = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskInTopic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskInTopic_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicId = table.Column<int>(nullable: true),
                    TaskId = table.Column<int>(nullable: true),
                    Note1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Note_TaskInTopic_TaskId",
                        column: x => x.TaskId,
                        principalTable: "TaskInTopic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Note_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Note_TaskId",
                table: "Note",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_TopicId",
                table: "Note",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskInTopic_TopicId",
                table: "TaskInTopic",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "TaskInTopic");

            migrationBuilder.DropTable(
                name: "Topic");
        }
    }
}
