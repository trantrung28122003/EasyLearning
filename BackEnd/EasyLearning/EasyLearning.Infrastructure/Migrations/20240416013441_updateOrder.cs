using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class updateOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderID",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Order_Id",
                table: "OrderDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CoursesId",
                table: "AddOns",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_Order_Id",
                table: "OrderDetails",
                column: "Order_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_Order_Id",
                table: "OrderDetails",
                column: "Order_Id",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_Order_Id",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_Order_Id",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Order_Id",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderID",
                table: "OrderDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CoursesId",
                table: "AddOns",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderID",
                table: "OrderDetails",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
