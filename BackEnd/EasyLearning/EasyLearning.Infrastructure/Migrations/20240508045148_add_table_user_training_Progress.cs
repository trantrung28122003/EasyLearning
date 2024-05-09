using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class add_table_user_training_Progress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTrainingProgress",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Training_Part_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Percentage_Watched = table.Column<double>(type: "float", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTrainingProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTrainingProgress_TrainingParts_Training_Part_Id",
                        column: x => x.Training_Part_Id,
                        principalTable: "TrainingParts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserTrainingProgress_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTrainingProgress_Training_Part_Id",
                table: "UserTrainingProgress",
                column: "Training_Part_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrainingProgress_User_Id",
                table: "UserTrainingProgress",
                column: "User_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTrainingProgress");
        }
    }
}
