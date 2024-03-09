using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskListApp.Database.Migrations
{
    public partial class AddFieldsToTaskItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskItemId",
                table: "TaskStatusHistories",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskItemId",
                table: "Comments",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskStatusHistories_TaskItemId",
                table: "TaskStatusHistories",
                column: "TaskItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TaskItemId",
                table: "Comments",
                column: "TaskItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_TaskItems_TaskItemId",
                table: "Comments",
                column: "TaskItemId",
                principalTable: "TaskItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskStatusHistories_TaskItems_TaskItemId",
                table: "TaskStatusHistories",
                column: "TaskItemId",
                principalTable: "TaskItems",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_TaskItems_TaskItemId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskStatusHistories_TaskItems_TaskItemId",
                table: "TaskStatusHistories");

            migrationBuilder.DropIndex(
                name: "IX_TaskStatusHistories_TaskItemId",
                table: "TaskStatusHistories");

            migrationBuilder.DropIndex(
                name: "IX_Comments_TaskItemId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TaskItemId",
                table: "TaskStatusHistories");

            migrationBuilder.DropColumn(
                name: "TaskItemId",
                table: "Comments");
        }
    }
}
