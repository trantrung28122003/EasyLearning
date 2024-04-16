using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class updateCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Courses_StartEnd",
                table: "Courses",
                newName: "Courses_EndDate");

            migrationBuilder.AddColumn<string>(
                name: "Courese_Instructor",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Courese_Instructor",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "Courses_EndDate",
                table: "Courses",
                newName: "Courses_StartEnd");
        }
    }
}
