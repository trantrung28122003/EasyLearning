using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class updatedatarole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
