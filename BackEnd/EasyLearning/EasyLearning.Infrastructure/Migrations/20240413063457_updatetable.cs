using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class updatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Course_Event_Date",
                table: "CourseEvents",
                newName: "Course_Event_Date_Start");

            migrationBuilder.AddColumn<DateTime>(
                name: "Course_Event_Date_End",
                table: "CourseEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course_Event_Date_End",
                table: "CourseEvents");

            migrationBuilder.RenameColumn(
                name: "Course_Event_Date_Start",
                table: "CourseEvents",
                newName: "Course_Event_Date");
        }
    }
}
