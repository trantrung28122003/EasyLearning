using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class updatetabletranning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranningParts_CourseEvents_TranningPartEventId",
                table: "TranningParts");

            migrationBuilder.DropIndex(
                name: "IX_TranningParts_TranningPartEventId",
                table: "TranningParts");

            migrationBuilder.DropColumn(
                name: "TranningPartEventId",
                table: "TranningParts");

            migrationBuilder.AlterColumn<string>(
                name: "Tranning_Part_Event_Id",
                table: "TranningParts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TranningParts_Tranning_Part_Event_Id",
                table: "TranningParts",
                column: "Tranning_Part_Event_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TranningParts_CourseEvents_Tranning_Part_Event_Id",
                table: "TranningParts",
                column: "Tranning_Part_Event_Id",
                principalTable: "CourseEvents",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranningParts_CourseEvents_Tranning_Part_Event_Id",
                table: "TranningParts");

            migrationBuilder.DropIndex(
                name: "IX_TranningParts_Tranning_Part_Event_Id",
                table: "TranningParts");

            migrationBuilder.AlterColumn<string>(
                name: "Tranning_Part_Event_Id",
                table: "TranningParts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TranningPartEventId",
                table: "TranningParts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TranningParts_TranningPartEventId",
                table: "TranningParts",
                column: "TranningPartEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_TranningParts_CourseEvents_TranningPartEventId",
                table: "TranningParts",
                column: "TranningPartEventId",
                principalTable: "CourseEvents",
                principalColumn: "Id");
        }
    }
}
