using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class update_table_usertrainingprogress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTrainingProgress_TrainingParts_Training_Part_Id",
                table: "UserTrainingProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTrainingProgress_Users_User_Id",
                table: "UserTrainingProgress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTrainingProgress",
                table: "UserTrainingProgress");

            migrationBuilder.RenameTable(
                name: "UserTrainingProgress",
                newName: "UserTrainingProgresss");

            migrationBuilder.RenameIndex(
                name: "IX_UserTrainingProgress_User_Id",
                table: "UserTrainingProgresss",
                newName: "IX_UserTrainingProgresss_User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_UserTrainingProgress_Training_Part_Id",
                table: "UserTrainingProgresss",
                newName: "IX_UserTrainingProgresss_Training_Part_Id");

            migrationBuilder.AlterColumn<decimal>(
                name: "Courses_Price",
                table: "Courses",
                type: "decimal(10,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTrainingProgresss",
                table: "UserTrainingProgresss",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrainingProgresss_TrainingParts_Training_Part_Id",
                table: "UserTrainingProgresss",
                column: "Training_Part_Id",
                principalTable: "TrainingParts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrainingProgresss_Users_User_Id",
                table: "UserTrainingProgresss",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTrainingProgresss_TrainingParts_Training_Part_Id",
                table: "UserTrainingProgresss");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTrainingProgresss_Users_User_Id",
                table: "UserTrainingProgresss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTrainingProgresss",
                table: "UserTrainingProgresss");

            migrationBuilder.RenameTable(
                name: "UserTrainingProgresss",
                newName: "UserTrainingProgress");

            migrationBuilder.RenameIndex(
                name: "IX_UserTrainingProgresss_User_Id",
                table: "UserTrainingProgress",
                newName: "IX_UserTrainingProgress_User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_UserTrainingProgresss_Training_Part_Id",
                table: "UserTrainingProgress",
                newName: "IX_UserTrainingProgress_Training_Part_Id");

            migrationBuilder.AlterColumn<decimal>(
                name: "Courses_Price",
                table: "Courses",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,3)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTrainingProgress",
                table: "UserTrainingProgress",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrainingProgress_TrainingParts_Training_Part_Id",
                table: "UserTrainingProgress",
                column: "Training_Part_Id",
                principalTable: "TrainingParts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTrainingProgress_Users_User_Id",
                table: "UserTrainingProgress",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
