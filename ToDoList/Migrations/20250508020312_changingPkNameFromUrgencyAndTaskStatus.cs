using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Migrations
{
    /// <inheritdoc />
    public partial class changingPkNameFromUrgencyAndTaskStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_UrgencyLevel_UrgencyLevelid",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UrgencyLevel",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UrgencyLevelid",
                table: "Task",
                newName: "UrgencyLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_UrgencyLevelid",
                table: "Task",
                newName: "IX_Task_UrgencyLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_UrgencyLevel_UrgencyLevelId",
                table: "Task",
                column: "UrgencyLevelId",
                principalTable: "UrgencyLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_UrgencyLevel_UrgencyLevelId",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UrgencyLevel",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UrgencyLevelId",
                table: "Task",
                newName: "UrgencyLevelid");

            migrationBuilder.RenameIndex(
                name: "IX_Task_UrgencyLevelId",
                table: "Task",
                newName: "IX_Task_UrgencyLevelid");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_UrgencyLevel_UrgencyLevelid",
                table: "Task",
                column: "UrgencyLevelid",
                principalTable: "UrgencyLevel",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
