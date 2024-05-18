using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class add_table_Exsercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Training_Part_Type",
                table: "TrainingParts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ExerciseQuestion",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExerciseQuestion_Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExerciseQuestion_CorrectChoiceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExerciseQuestion_TrainingPartId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExerciseQuestion_TrainingPartId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseQuestion_TrainingParts_ExerciseQuestion_TrainingPartId1",
                        column: x => x.ExerciseQuestion_TrainingPartId1,
                        principalTable: "TrainingParts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Answer_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer_QuestionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answer_ExerciseQuestion_Answer_QuestionId",
                        column: x => x.Answer_QuestionId,
                        principalTable: "ExerciseQuestion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserExserciseAnswer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ExerciseQuestion_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SelectedAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExserciseAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserExserciseAnswer_ExerciseQuestion_ExerciseQuestion_Id",
                        column: x => x.ExerciseQuestion_Id,
                        principalTable: "ExerciseQuestion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserExserciseAnswer_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_Answer_QuestionId",
                table: "Answer",
                column: "Answer_QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseQuestion_ExerciseQuestion_TrainingPartId1",
                table: "ExerciseQuestion",
                column: "ExerciseQuestion_TrainingPartId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserExserciseAnswer_ExerciseQuestion_Id",
                table: "UserExserciseAnswer",
                column: "ExerciseQuestion_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserExserciseAnswer_User_Id",
                table: "UserExserciseAnswer",
                column: "User_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "UserExserciseAnswer");

            migrationBuilder.DropTable(
                name: "ExerciseQuestion");

            migrationBuilder.DropColumn(
                name: "Training_Part_Type",
                table: "TrainingParts");
        }
    }
}
