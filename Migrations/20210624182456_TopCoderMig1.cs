using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopcoderNetApi.Migrations
{
    public partial class TopCoderMig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Courses",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Name = table.Column<string>("nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Courses", x => x.Id); });

            migrationBuilder.CreateTable(
                "Users",
                table => new
                {
                    Id = table.Column<string>("nvarchar(450)", nullable: false),
                    FullName = table.Column<string>("nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });

            migrationBuilder.CreateTable(
                "Sections",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Name = table.Column<string>("nvarchar(250)", maxLength: 250, nullable: false),
                    Order = table.Column<int>("int", nullable: false),
                    CourseId = table.Column<Guid>("uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        "FK_Sections_Courses_CourseId",
                        x => x.CourseId,
                        "Courses",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Lessons",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Name = table.Column<string>("nvarchar(250)", maxLength: 250, nullable: false),
                    VideoUrl = table.Column<string>("nvarchar(355)", maxLength: 355, nullable: true),
                    Order = table.Column<int>("int", nullable: false),
                    SectionId = table.Column<Guid>("uniqueidentifier", nullable: true),
                    IsCompleted = table.Column<bool>("bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        "FK_Lessons_Sections_SectionId",
                        x => x.SectionId,
                        "Sections",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "WatchLogs",
                table => new
                {
                    Id = table.Column<string>("nvarchar(450)", nullable: false),
                    CourseId = table.Column<Guid>("uniqueidentifier", nullable: true),
                    LessonId = table.Column<Guid>("uniqueidentifier", nullable: true),
                    UserId = table.Column<string>("nvarchar(450)", nullable: true),
                    PercentageWatched = table.Column<int>("int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchLogs", x => x.Id);
                    table.ForeignKey(
                        "FK_WatchLogs_Courses_CourseId",
                        x => x.CourseId,
                        "Courses",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_WatchLogs_Lessons_LessonId",
                        x => x.LessonId,
                        "Lessons",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_WatchLogs_Users_UserId",
                        x => x.UserId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Lessons_SectionId",
                "Lessons",
                "SectionId");

            migrationBuilder.CreateIndex(
                "IX_Sections_CourseId",
                "Sections",
                "CourseId");

            migrationBuilder.CreateIndex(
                "IX_WatchLogs_CourseId",
                "WatchLogs",
                "CourseId");

            migrationBuilder.CreateIndex(
                "IX_WatchLogs_LessonId",
                "WatchLogs",
                "LessonId");

            migrationBuilder.CreateIndex(
                "IX_WatchLogs_UserId",
                "WatchLogs",
                "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "WatchLogs");

            migrationBuilder.DropTable(
                "Lessons");

            migrationBuilder.DropTable(
                "Users");

            migrationBuilder.DropTable(
                "Sections");

            migrationBuilder.DropTable(
                "Courses");
        }
    }
}