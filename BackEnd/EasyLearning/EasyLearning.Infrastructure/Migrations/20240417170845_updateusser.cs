using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class updateusser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "46203f9c-60e9-4df1-ab1e-5a1a2fd15fea");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c34c4a5f-dbd3-4e44-8ac5-6122b4e9d0a4");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d9c8447f-d0db-4242-8d4a-d680fd713b86");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28d6e3f3-fd28-44a7-b84f-efcc4742b1a6", "4baa885e-b2b7-4608-8182-ddc65c7089f9", "Trainer", "TRAINER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b9f8c82f-459d-4d3e-bc08-9c8bf0c915b5", "02f6eda8-2355-4838-bce2-86f1ba2c44a6", "Admin", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "de6c71e6-80f3-4b8c-adce-c90779c42de2", "33312d77-50d8-4caf-9944-0a0d6d951d6f", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "28d6e3f3-fd28-44a7-b84f-efcc4742b1a6");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b9f8c82f-459d-4d3e-bc08-9c8bf0c915b5");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "de6c71e6-80f3-4b8c-adce-c90779c42de2");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "46203f9c-60e9-4df1-ab1e-5a1a2fd15fea", "56007e57-1ec0-456d-99af-b4030bac6cc7", "Trainer", "TRAINER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c34c4a5f-dbd3-4e44-8ac5-6122b4e9d0a4", "e912904c-c459-4a55-939f-957aec426563", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d9c8447f-d0db-4242-8d4a-d680fd713b86", "9787362b-3c50-4b91-a322-78958c9161e4", "Admin", "ADMINISTRATOR" });
        }
    }
}
