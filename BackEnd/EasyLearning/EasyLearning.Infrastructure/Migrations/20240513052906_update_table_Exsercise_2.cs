using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class update_table_Exsercise_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseQuestions_TrainingParts_ExerciseQuestion_TrainingPartId1",
                table: "ExerciseQuestions");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseQuestions_ExerciseQuestion_TrainingPartId1",
                table: "ExerciseQuestions");

            migrationBuilder.DropColumn(
                name: "ExerciseQuestion_TrainingPartId1",
                table: "ExerciseQuestions");

            migrationBuilder.AlterColumn<string>(
                name: "ExerciseQuestion_TrainingPartId",
                table: "ExerciseQuestions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseQuestions_ExerciseQuestion_TrainingPartId",
                table: "ExerciseQuestions",
                column: "ExerciseQuestion_TrainingPartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseQuestions_TrainingParts_ExerciseQuestion_TrainingPartId",
                table: "ExerciseQuestions",
                column: "ExerciseQuestion_TrainingPartId",
                principalTable: "TrainingParts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseQuestions_TrainingParts_ExerciseQuestion_TrainingPartId",
                table: "ExerciseQuestions");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseQuestions_ExerciseQuestion_TrainingPartId",
                table: "ExerciseQuestions");

            migrationBuilder.AlterColumn<string>(
                name: "ExerciseQuestion_TrainingPartId",
                table: "ExerciseQuestions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExerciseQuestion_TrainingPartId1",
                table: "ExerciseQuestions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseQuestions_ExerciseQuestion_TrainingPartId1",
                table: "ExerciseQuestions",
                column: "ExerciseQuestion_TrainingPartId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseQuestions_TrainingParts_ExerciseQuestion_TrainingPartId1",
                table: "ExerciseQuestions",
                column: "ExerciseQuestion_TrainingPartId1",
                principalTable: "TrainingParts",
                principalColumn: "Id");
        }
    }
}
