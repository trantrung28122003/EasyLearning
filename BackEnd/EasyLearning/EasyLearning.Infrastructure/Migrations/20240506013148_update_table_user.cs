using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class update_table_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_TrannerDetails_TrainnerDetailId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TrainnerDetailId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TrainnerDetailId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "TrainnerDetailId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TrainnerDetailId",
                table: "Users",
                column: "TrainnerDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_TrannerDetails_TrainnerDetailId",
                table: "Users",
                column: "TrainnerDetailId",
                principalTable: "TrannerDetails",
                principalColumn: "Id");
        }
    }
}
