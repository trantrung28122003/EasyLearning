using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class Add : Migration
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
                values: new object[] { "1b5656ee-8716-4694-b81c-7b84a03802de", "1c77dbfa-21c9-4a4a-9c81-76f83e83b9b2", "Admin", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d699bd5d-5be0-41fa-85c0-fc853065deda", "726edcdb-b766-4080-b179-e33562147977", "Trainer", "TRAINER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d8219626-31ac-4849-a384-8aa84322f86d", "c302c6c6-a454-485e-81b4-5da0a31cc01d", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1b5656ee-8716-4694-b81c-7b84a03802de");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d699bd5d-5be0-41fa-85c0-fc853065deda");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d8219626-31ac-4849-a384-8aa84322f86d");

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
