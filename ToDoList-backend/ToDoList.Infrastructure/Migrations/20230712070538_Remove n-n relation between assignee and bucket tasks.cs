using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    public partial class Removennrelationbetweenassigneeandbuckettasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssigneeBucketTask");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssigneeBucketTask",
                columns: table => new
                {
                    AssigneeId = table.Column<int>(type: "int", nullable: false),
                    BucketTaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssigneeBucketTask", x => new { x.AssigneeId, x.BucketTaskId });
                    table.ForeignKey(
                        name: "FK_AssigneeBucketTask_Assignees_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "Assignees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssigneeBucketTask_BucketTasks_BucketTaskId",
                        column: x => x.BucketTaskId,
                        principalTable: "BucketTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssigneeBucketTask_BucketTaskId",
                table: "AssigneeBucketTask",
                column: "BucketTaskId");
        }
    }
}
