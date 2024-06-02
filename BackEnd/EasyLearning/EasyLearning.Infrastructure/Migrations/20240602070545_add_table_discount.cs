using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class add_table_discount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Order_Quantity",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order_Quantity",
                table: "Orders");
        }
    }
}
