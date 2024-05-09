using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class update_table_Training : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranningParts_CourseEvents_Tranning_Part_Event_Id",
                table: "TranningParts");

            migrationBuilder.DropForeignKey(
                name: "FK_TranningParts_Courses_Tranning_Part_Courese_Id",
                table: "TranningParts");

            migrationBuilder.RenameColumn(
                name: "Tranning_Part_StartTime",
                table: "TranningParts",
                newName: "Training_Part_StartTime");

            migrationBuilder.RenameColumn(
                name: "Tranning_Part_Event_Id",
                table: "TranningParts",
                newName: "Training_Part_Event_Id");

            migrationBuilder.RenameColumn(
                name: "Tranning_Part_EndTime",
                table: "TranningParts",
                newName: "Training_Part_EndTime");

            migrationBuilder.RenameColumn(
                name: "Tranning_Part_Description",
                table: "TranningParts",
                newName: "Training_Part_Description");

            migrationBuilder.RenameColumn(
                name: "Tranning_Part_Courese_Id",
                table: "TranningParts",
                newName: "Training_Part_Courese_Id");

            migrationBuilder.RenameColumn(
                name: "Tranning_Part_Name",
                table: "TranningParts",
                newName: "Training_Part_Name");

            migrationBuilder.RenameIndex(
                name: "IX_TranningParts_Tranning_Part_Event_Id",
                table: "TranningParts",
                newName: "IX_TranningParts_Training_Part_Event_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TranningParts_Tranning_Part_Courese_Id",
                table: "TranningParts",
                newName: "IX_TranningParts_Training_Part_Courese_Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranningParts_CourseEvents_Training_Part_Event_Id",
                table: "TranningParts");

            migrationBuilder.DropForeignKey(
                name: "FK_TranningParts_Courses_Training_Part_Courese_Id",
                table: "TranningParts");

            migrationBuilder.RenameColumn(
                name: "Training_Part_StartTime",
                table: "TranningParts",
                newName: "Tranning_Part_StartTime");

            migrationBuilder.RenameColumn(
                name: "Training_Part_Event_Id",
                table: "TranningParts",
                newName: "Tranning_Part_Event_Id");

            migrationBuilder.RenameColumn(
                name: "Training_Part_EndTime",
                table: "TranningParts",
                newName: "Tranning_Part_EndTime");

            migrationBuilder.RenameColumn(
                name: "Training_Part_Description",
                table: "TranningParts",
                newName: "Tranning_Part_Description");

            migrationBuilder.RenameColumn(
                name: "Training_Part_Courese_Id",
                table: "TranningParts",
                newName: "Tranning_Part_Courese_Id");

            migrationBuilder.RenameColumn(
                name: "Training_Part_Name",
                table: "TranningParts",
                newName: "Tranning_Part_Name");

            migrationBuilder.RenameIndex(
                name: "IX_TranningParts_Training_Part_Event_Id",
                table: "TranningParts",
                newName: "IX_TranningParts_Tranning_Part_Event_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TranningParts_Training_Part_Courese_Id",
                table: "TranningParts",
                newName: "IX_TranningParts_Tranning_Part_Courese_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TranningParts_CourseEvents_Tranning_Part_Event_Id",
                table: "TranningParts",
                column: "Tranning_Part_Event_Id",
                principalTable: "CourseEvents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TranningParts_Courses_Tranning_Part_Courese_Id",
                table: "TranningParts",
                column: "Tranning_Part_Courese_Id",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}
