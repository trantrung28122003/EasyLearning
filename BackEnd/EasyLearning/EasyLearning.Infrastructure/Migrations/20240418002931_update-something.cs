using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class updatesomething : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_TrannerDetails_TrannerDetailId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "TrannerDetailId",
                table: "Users",
                newName: "TrainnerDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_TrannerDetailId",
                table: "Users",
                newName: "IX_Users_TrainnerDetailId");

            migrationBuilder.RenameColumn(
                name: "Courese_RegistrationDeadline",
                table: "Courses",
                newName: "Courses_RegistrationDeadline");

            migrationBuilder.RenameColumn(
                name: "Courese_Instructor",
                table: "Courses",
                newName: "Courses_Instructor");

            migrationBuilder.RenameColumn(
                name: "Courese_ImageUrl",
                table: "Courses",
                newName: "Courses_ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "UserImageUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_TrannerDetails_TrainnerDetailId",
                table: "Users",
                column: "TrainnerDetailId",
                principalTable: "TrannerDetails",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_TrannerDetails_TrainnerDetailId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserImageUrl",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "TrainnerDetailId",
                table: "Users",
                newName: "TrannerDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_TrainnerDetailId",
                table: "Users",
                newName: "IX_Users_TrannerDetailId");

            migrationBuilder.RenameColumn(
                name: "Courses_RegistrationDeadline",
                table: "Courses",
                newName: "Courese_RegistrationDeadline");

            migrationBuilder.RenameColumn(
                name: "Courses_Instructor",
                table: "Courses",
                newName: "Courese_Instructor");

            migrationBuilder.RenameColumn(
                name: "Courses_ImageUrl",
                table: "Courses",
                newName: "Courese_ImageUrl");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_TrannerDetails_TrannerDetailId",
                table: "Users",
                column: "TrannerDetailId",
                principalTable: "TrannerDetails",
                principalColumn: "Id");
        }
    }
}
