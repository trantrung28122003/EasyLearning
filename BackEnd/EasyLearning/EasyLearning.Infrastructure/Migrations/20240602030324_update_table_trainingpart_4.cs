using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class update_table_trainingpart_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Training_Part_IsFree",
                table: "TrainingParts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Training_Part_IsFree",
                table: "TrainingParts");
        }
    }
}
