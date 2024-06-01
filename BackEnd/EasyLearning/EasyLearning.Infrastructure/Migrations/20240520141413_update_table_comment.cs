using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearning.Infrastructure.Migrations
{
    public partial class update_table_comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_TrainingParts_TrainingPartId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Reply_Comment_CommmentId",
                table: "Reply");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reply",
                table: "Reply");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Reply",
                newName: "Replies");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameColumn(
                name: "Comment_UserId",
                table: "Replies",
                newName: "Reply_UserId");

            migrationBuilder.RenameColumn(
                name: "Comment_Content",
                table: "Replies",
                newName: "Reply_Content");

            migrationBuilder.RenameColumn(
                name: "CommmentId",
                table: "Replies",
                newName: "Reply_CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Reply_CommmentId",
                table: "Replies",
                newName: "IX_Replies_Reply_CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_TrainingPartId",
                table: "Comments",
                newName: "IX_Comments_TrainingPartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Replies",
                table: "Replies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_TrainingParts_TrainingPartId",
                table: "Comments",
                column: "TrainingPartId",
                principalTable: "TrainingParts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Comments_Reply_CommentId",
                table: "Replies",
                column: "Reply_CommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_TrainingParts_TrainingPartId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Comments_Reply_CommentId",
                table: "Replies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Replies",
                table: "Replies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Replies",
                newName: "Reply");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "Reply_UserId",
                table: "Reply",
                newName: "Comment_UserId");

            migrationBuilder.RenameColumn(
                name: "Reply_Content",
                table: "Reply",
                newName: "Comment_Content");

            migrationBuilder.RenameColumn(
                name: "Reply_CommentId",
                table: "Reply",
                newName: "CommmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Replies_Reply_CommentId",
                table: "Reply",
                newName: "IX_Reply_CommmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_TrainingPartId",
                table: "Comment",
                newName: "IX_Comment_TrainingPartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reply",
                table: "Reply",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_TrainingParts_TrainingPartId",
                table: "Comment",
                column: "TrainingPartId",
                principalTable: "TrainingParts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reply_Comment_CommmentId",
                table: "Reply",
                column: "CommmentId",
                principalTable: "Comment",
                principalColumn: "Id");
        }
    }
}
