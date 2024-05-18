using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class update_table_Exsercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_ExerciseQuestion_Answer_QuestionId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseQuestion_TrainingParts_ExerciseQuestion_TrainingPartId1",
                table: "ExerciseQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExserciseAnswer_ExerciseQuestion_ExerciseQuestion_Id",
                table: "UserExserciseAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExserciseAnswer_Users_User_Id",
                table: "UserExserciseAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserExserciseAnswer",
                table: "UserExserciseAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseQuestion",
                table: "ExerciseQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answer",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "ExerciseQuestion_CorrectChoiceId",
                table: "ExerciseQuestion");

            migrationBuilder.RenameTable(
                name: "UserExserciseAnswer",
                newName: "UserExserciseAnswers");

            migrationBuilder.RenameTable(
                name: "ExerciseQuestion",
                newName: "ExerciseQuestions");

            migrationBuilder.RenameTable(
                name: "Answer",
                newName: "Answers");

            migrationBuilder.RenameIndex(
                name: "IX_UserExserciseAnswer_User_Id",
                table: "UserExserciseAnswers",
                newName: "IX_UserExserciseAnswers_User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_UserExserciseAnswer_ExerciseQuestion_Id",
                table: "UserExserciseAnswers",
                newName: "IX_UserExserciseAnswers_ExerciseQuestion_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseQuestion_ExerciseQuestion_TrainingPartId1",
                table: "ExerciseQuestions",
                newName: "IX_ExerciseQuestions_ExerciseQuestion_TrainingPartId1");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_Answer_QuestionId",
                table: "Answers",
                newName: "IX_Answers_Answer_QuestionId");

            migrationBuilder.AddColumn<bool>(
                name: "Answer_IsCorrect",
                table: "Answers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserExserciseAnswers",
                table: "UserExserciseAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseQuestions",
                table: "ExerciseQuestions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answers",
                table: "Answers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_ExerciseQuestions_Answer_QuestionId",
                table: "Answers",
                column: "Answer_QuestionId",
                principalTable: "ExerciseQuestions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseQuestions_TrainingParts_ExerciseQuestion_TrainingPartId1",
                table: "ExerciseQuestions",
                column: "ExerciseQuestion_TrainingPartId1",
                principalTable: "TrainingParts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExserciseAnswers_ExerciseQuestions_ExerciseQuestion_Id",
                table: "UserExserciseAnswers",
                column: "ExerciseQuestion_Id",
                principalTable: "ExerciseQuestions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExserciseAnswers_Users_User_Id",
                table: "UserExserciseAnswers",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_ExerciseQuestions_Answer_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseQuestions_TrainingParts_ExerciseQuestion_TrainingPartId1",
                table: "ExerciseQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExserciseAnswers_ExerciseQuestions_ExerciseQuestion_Id",
                table: "UserExserciseAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExserciseAnswers_Users_User_Id",
                table: "UserExserciseAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserExserciseAnswers",
                table: "UserExserciseAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseQuestions",
                table: "ExerciseQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answers",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "Answer_IsCorrect",
                table: "Answers");

            migrationBuilder.RenameTable(
                name: "UserExserciseAnswers",
                newName: "UserExserciseAnswer");

            migrationBuilder.RenameTable(
                name: "ExerciseQuestions",
                newName: "ExerciseQuestion");

            migrationBuilder.RenameTable(
                name: "Answers",
                newName: "Answer");

            migrationBuilder.RenameIndex(
                name: "IX_UserExserciseAnswers_User_Id",
                table: "UserExserciseAnswer",
                newName: "IX_UserExserciseAnswer_User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_UserExserciseAnswers_ExerciseQuestion_Id",
                table: "UserExserciseAnswer",
                newName: "IX_UserExserciseAnswer_ExerciseQuestion_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseQuestions_ExerciseQuestion_TrainingPartId1",
                table: "ExerciseQuestion",
                newName: "IX_ExerciseQuestion_ExerciseQuestion_TrainingPartId1");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_Answer_QuestionId",
                table: "Answer",
                newName: "IX_Answer_Answer_QuestionId");

            migrationBuilder.AddColumn<string>(
                name: "ExerciseQuestion_CorrectChoiceId",
                table: "ExerciseQuestion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserExserciseAnswer",
                table: "UserExserciseAnswer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseQuestion",
                table: "ExerciseQuestion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answer",
                table: "Answer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_ExerciseQuestion_Answer_QuestionId",
                table: "Answer",
                column: "Answer_QuestionId",
                principalTable: "ExerciseQuestion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseQuestion_TrainingParts_ExerciseQuestion_TrainingPartId1",
                table: "ExerciseQuestion",
                column: "ExerciseQuestion_TrainingPartId1",
                principalTable: "TrainingParts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExserciseAnswer_ExerciseQuestion_ExerciseQuestion_Id",
                table: "UserExserciseAnswer",
                column: "ExerciseQuestion_Id",
                principalTable: "ExerciseQuestion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExserciseAnswer_Users_User_Id",
                table: "UserExserciseAnswer",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
