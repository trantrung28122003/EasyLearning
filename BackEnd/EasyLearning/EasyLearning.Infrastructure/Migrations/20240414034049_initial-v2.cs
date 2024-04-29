using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class initialv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_Shopping_Cart_User_Id",
                table: "ShoppingCarts");

            migrationBuilder.AddColumn<string>(
                name: "trainerDetailId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_trainerDetailId",
                table: "Users",
                column: "trainerDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_Shopping_Cart_User_Id",
                table: "ShoppingCarts",
                column: "Shopping_Cart_User_Id",
                unique: true,
                filter: "[Shopping_Cart_User_Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_trainerDetails_trainerDetailId",
                table: "Users",
                column: "trainerDetailId",
                principalTable: "trainerDetails",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_trainerDetails_trainerDetailId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_trainerDetailId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_Shopping_Cart_User_Id",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "trainerDetailId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_Shopping_Cart_User_Id",
                table: "ShoppingCarts",
                column: "Shopping_Cart_User_Id");
        }
    }
}
