using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class RemoveUserExerciseAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserExserciseAnswers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserExserciseAnswers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExerciseQuestion_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SelectedAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExserciseAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserExserciseAnswers_ExerciseQuestions_ExerciseQuestion_Id",
                        column: x => x.ExerciseQuestion_Id,
                        principalTable: "ExerciseQuestions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserExserciseAnswers_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserExserciseAnswers_ExerciseQuestion_Id",
                table: "UserExserciseAnswers",
                column: "ExerciseQuestion_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserExserciseAnswers_User_Id",
                table: "UserExserciseAnswers",
                column: "User_Id");
        }
    }
}
