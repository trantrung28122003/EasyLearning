using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class add_table_discount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discount_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount_Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseDiscounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseDiscount_CourseId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CourseDiscount_DiscountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseDiscounts_Courses_CourseDiscount_CourseId",
                        column: x => x.CourseDiscount_CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseDiscounts_Discounts_CourseDiscount_DiscountId",
                        column: x => x.CourseDiscount_DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDiscounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseDiscount_OrderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CourseDiscount_DiscountId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDiscounts_Discounts_CourseDiscount_DiscountId",
                        column: x => x.CourseDiscount_DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDiscounts_Orders_CourseDiscount_OrderId",
                        column: x => x.CourseDiscount_OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseDiscounts_CourseDiscount_CourseId",
                table: "CourseDiscounts",
                column: "CourseDiscount_CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDiscounts_CourseDiscount_DiscountId",
                table: "CourseDiscounts",
                column: "CourseDiscount_DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDiscounts_CourseDiscount_DiscountId",
                table: "OrderDiscounts",
                column: "CourseDiscount_DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDiscounts_CourseDiscount_OrderId",
                table: "OrderDiscounts",
                column: "CourseDiscount_OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseDiscounts");

            migrationBuilder.DropTable(
                name: "OrderDiscounts");

            migrationBuilder.DropTable(
                name: "Discounts");
        }
    }
}
