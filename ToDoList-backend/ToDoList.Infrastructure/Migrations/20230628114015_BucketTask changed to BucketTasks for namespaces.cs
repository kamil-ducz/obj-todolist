using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    public partial class BucketTaskchangedtoBucketTasksfornamespaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssigneesBucketTask");

            migrationBuilder.CreateTable(
                name: "AssigneesBucketTasks",
                columns: table => new
                {
                    AssigneesId = table.Column<int>(type: "int", nullable: false),
                    BucketTasksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssigneesBucketTasks", x => new { x.AssigneesId, x.BucketTasksId });
                    table.ForeignKey(
                        name: "FK_AssigneesBucketTasks_Assignees_AssigneesId",
                        column: x => x.AssigneesId,
                        principalTable: "Assignees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssigneesBucketTasks_BucketTasks_BucketTasksId",
                        column: x => x.BucketTasksId,
                        principalTable: "BucketTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssigneesBucketTasks_BucketTasksId",
                table: "AssigneesBucketTasks",
                column: "BucketTasksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssigneesBucketTasks");

            migrationBuilder.CreateTable(
                name: "AssigneesBucketTask",
                columns: table => new
                {
                    AssigneesId = table.Column<int>(type: "int", nullable: false),
                    BucketTasksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssigneesBucketTask", x => new { x.AssigneesId, x.BucketTasksId });
                    table.ForeignKey(
                        name: "FK_AssigneesBucketTask_Assignees_AssigneesId",
                        column: x => x.AssigneesId,
                        principalTable: "Assignees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssigneesBucketTask_BucketTasks_BucketTasksId",
                        column: x => x.BucketTasksId,
                        principalTable: "BucketTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssigneesBucketTask_BucketTasksId",
                table: "AssigneesBucketTask",
                column: "BucketTasksId");
        }
    }
}
