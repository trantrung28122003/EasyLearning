using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class update_table_07_07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainerDetails_Courses_TrainerDetail_Courses_Id",
                table: "TrainerDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerDetails_Users_TrainerDetail_User_Id",
                table: "TrainerDetails");

            migrationBuilder.RenameColumn(
                name: "TrainerDetail_User_Id",
                table: "TrainerDetails",
                newName: "User_Id");

            migrationBuilder.RenameColumn(
                name: "TrainerDetail_Courses_Id",
                table: "TrainerDetails",
                newName: "Courses_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TrainerDetails_TrainerDetail_User_Id",
                table: "TrainerDetails",
                newName: "IX_TrainerDetails_User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TrainerDetails_TrainerDetail_Courses_Id",
                table: "TrainerDetails",
                newName: "IX_TrainerDetails_Courses_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerDetails_Courses_Courses_Id",
                table: "TrainerDetails",
                column: "Courses_Id",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerDetails_Users_User_Id",
                table: "TrainerDetails",
                column: "User_Id",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainerDetails_Courses_Courses_Id",
                table: "TrainerDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerDetails_Users_User_Id",
                table: "TrainerDetails");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "TrainerDetails",
                newName: "TrainerDetail_User_Id");

            migrationBuilder.RenameColumn(
                name: "Courses_Id",
                table: "TrainerDetails",
                newName: "TrainerDetail_Courses_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TrainerDetails_User_Id",
                table: "TrainerDetails",
                newName: "IX_TrainerDetails_TrainerDetail_User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TrainerDetails_Courses_Id",
                table: "TrainerDetails",
                newName: "IX_TrainerDetails_TrainerDetail_Courses_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerDetails_Courses_TrainerDetail_Courses_Id",
                table: "TrainerDetails",
                column: "TrainerDetail_Courses_Id",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerDetails_Users_TrainerDetail_User_Id",
                table: "TrainerDetails",
                column: "TrainerDetail_User_Id",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
