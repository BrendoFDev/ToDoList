using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Migrations
{
    /// <inheritdoc />
    public partial class fixForeignkeyInTaskTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_TaskStatus_TaskStatusId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_UrgencyLevel_UrgencyLevelId",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Task",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TaskStatus_TaskStatusId",
                table: "Task",
                column: "TaskStatusId",
                principalTable: "TaskStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_UrgencyLevel_UrgencyLevelId",
                table: "Task",
                column: "UrgencyLevelId",
                principalTable: "UrgencyLevel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_TaskStatus_TaskStatusId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_UrgencyLevel_UrgencyLevelId",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Task",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TaskStatus_TaskStatusId",
                table: "Task",
                column: "TaskStatusId",
                principalTable: "TaskStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_UrgencyLevel_UrgencyLevelId",
                table: "Task",
                column: "UrgencyLevelId",
                principalTable: "UrgencyLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
