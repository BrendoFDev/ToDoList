using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ToDoList.Migrations
{
    /// <inheritdoc />
    public partial class addUrgencyLevelAndTaskStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "urgencyLevel",
                table: "Task",
                newName: "UrgencyLevelid");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Task",
                newName: "TaskStatusId");

            migrationBuilder.CreateTable(
                name: "TaskStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UrgencyLevel",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrgencyLevel", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_TaskStatusId",
                table: "Task",
                column: "TaskStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_UrgencyLevelid",
                table: "Task",
                column: "UrgencyLevelid");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_TaskStatus_TaskStatusId",
                table: "Task",
                column: "TaskStatusId",
                principalTable: "TaskStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_UrgencyLevel_UrgencyLevelid",
                table: "Task",
                column: "UrgencyLevelid",
                principalTable: "UrgencyLevel",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_TaskStatus_TaskStatusId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_UrgencyLevel_UrgencyLevelid",
                table: "Task");

            migrationBuilder.DropTable(
                name: "TaskStatus");

            migrationBuilder.DropTable(
                name: "UrgencyLevel");

            migrationBuilder.DropIndex(
                name: "IX_Task_TaskStatusId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_UrgencyLevelid",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "UrgencyLevelid",
                table: "Task",
                newName: "urgencyLevel");

            migrationBuilder.RenameColumn(
                name: "TaskStatusId",
                table: "Task",
                newName: "status");
        }
    }
}
