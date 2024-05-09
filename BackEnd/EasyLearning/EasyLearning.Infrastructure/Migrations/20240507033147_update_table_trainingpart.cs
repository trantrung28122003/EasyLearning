using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class update_table_trainingpart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranningParts_CourseEvents_Training_Part_Event_Id",
                table: "TranningParts");

            migrationBuilder.DropForeignKey(
                name: "FK_TranningParts_Courses_Training_Part_Courese_Id",
                table: "TranningParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TranningParts",
                table: "TranningParts");

            migrationBuilder.RenameTable(
                name: "TranningParts",
                newName: "TrainingParts");

            migrationBuilder.RenameIndex(
                name: "IX_TranningParts_Training_Part_Event_Id",
                table: "TrainingParts",
                newName: "IX_TrainingParts_Training_Part_Event_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TranningParts_Training_Part_Courese_Id",
                table: "TrainingParts",
                newName: "IX_TrainingParts_Training_Part_Courese_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingParts",
                table: "TrainingParts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingParts_CourseEvents_Training_Part_Event_Id",
                table: "TrainingParts",
                column: "Training_Part_Event_Id",
                principalTable: "CourseEvents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingParts_Courses_Training_Part_Courese_Id",
                table: "TrainingParts",
                column: "Training_Part_Courese_Id",
                principalTable: "Courses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingParts_CourseEvents_Training_Part_Event_Id",
                table: "TrainingParts");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingParts_Courses_Training_Part_Courese_Id",
                table: "TrainingParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingParts",
                table: "TrainingParts");

            migrationBuilder.RenameTable(
                name: "TrainingParts",
                newName: "TranningParts");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingParts_Training_Part_Event_Id",
                table: "TranningParts",
                newName: "IX_TranningParts_Training_Part_Event_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingParts_Training_Part_Courese_Id",
                table: "TranningParts",
                newName: "IX_TranningParts_Training_Part_Courese_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TranningParts",
                table: "TranningParts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TranningParts_CourseEvents_Training_Part_Event_Id",
                table: "TranningParts",
                column: "Training_Part_Event_Id",
                principalTable: "CourseEvents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TranningParts_Courses_Training_Part_Courese_Id",
                table: "TranningParts",
                column: "Training_Part_Courese_Id",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}
