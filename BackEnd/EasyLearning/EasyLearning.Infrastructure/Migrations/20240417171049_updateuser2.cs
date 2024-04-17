using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class updateuser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Courese_ImageUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8dfabc5f-abf9-4782-bdeb-ad08185f2ca9", "5d5779a1-0ec0-4268-aea2-0d3626d1bbd6", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a68b3dde-5b9e-47f7-8238-0547d71409ef", "dfa89656-4c6e-40d8-9a71-4a2398b61fbb", "Trainer", "TRAINER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f1789ad2-e451-44f0-a0b8-45c666d14f44", "70c6062a-a7b2-448f-900a-735668de5483", "Admin", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8dfabc5f-abf9-4782-bdeb-ad08185f2ca9");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a68b3dde-5b9e-47f7-8238-0547d71409ef");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f1789ad2-e451-44f0-a0b8-45c666d14f44");

            migrationBuilder.DropColumn(
                name: "Courese_ImageUrl",
                table: "Users");

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
    }
}
