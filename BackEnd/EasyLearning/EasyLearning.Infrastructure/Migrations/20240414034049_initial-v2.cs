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
                name: "TrannerDetailId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TrannerDetailId",
                table: "Users",
                column: "TrannerDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_Shopping_Cart_User_Id",
                table: "ShoppingCarts",
                column: "Shopping_Cart_User_Id",
                unique: true,
                filter: "[Shopping_Cart_User_Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_TrannerDetails_TrannerDetailId",
                table: "Users",
                column: "TrannerDetailId",
                principalTable: "TrannerDetails",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_TrannerDetails_TrannerDetailId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TrannerDetailId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_Shopping_Cart_User_Id",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "TrannerDetailId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_Shopping_Cart_User_Id",
                table: "ShoppingCarts",
                column: "Shopping_Cart_User_Id");
        }
    }
}
