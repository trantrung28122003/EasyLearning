using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class initialll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "52ed63d2-c2a5-4741-be50-a44d79d37909");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7ff2b54f-79e1-4662-9dab-f9975959ba63");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ecd4c348-69f6-4343-9881-31f4c995e3e9");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "76484ccb-20a0-42df-8b87-e1afb2f1809e", "4bcc1032-6332-4281-842b-fbea50234cdf", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8197c03f-4837-42d9-8753-11f3ca8f064b", "5da81c57-69e6-489c-bfc2-cc47af5de297", "Admin", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c09b9684-0b3a-4288-87c2-0fe2d12dd125", "20e8abfa-fe34-415e-83fa-c85f6eacafed", "Trainer", "TRAINER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "76484ccb-20a0-42df-8b87-e1afb2f1809e");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8197c03f-4837-42d9-8753-11f3ca8f064b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c09b9684-0b3a-4288-87c2-0fe2d12dd125");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "52ed63d2-c2a5-4741-be50-a44d79d37909", "02db527e-7128-459f-99ee-260ae2dd8ec9", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7ff2b54f-79e1-4662-9dab-f9975959ba63", "f164fcbb-fcc2-4794-b41b-3ac2025374f9", "Admin", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ecd4c348-69f6-4343-9881-31f4c995e3e9", "f0644fbd-4e46-40ae-9ccb-a603a4b033e3", "Trainer", "TRAINER" });
        }
    }
}
