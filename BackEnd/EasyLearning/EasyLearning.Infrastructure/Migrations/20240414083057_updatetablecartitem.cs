using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class updatetablecartitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Shopping_Cart_Item_Quantity",
                table: "ShoppingCartItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Shopping_Cart_Item_ImageUrl",
                table: "ShoppingCartItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Shopping_Cart_Item_Name",
                table: "ShoppingCartItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Shopping_Cart_Item_Price",
                table: "ShoppingCartItems",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shopping_Cart_Item_ImageUrl",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "Shopping_Cart_Item_Name",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "Shopping_Cart_Item_Price",
                table: "ShoppingCartItems");

            migrationBuilder.AlterColumn<int>(
                name: "Shopping_Cart_Item_Quantity",
                table: "ShoppingCartItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
