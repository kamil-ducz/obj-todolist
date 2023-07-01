using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations;

public partial class AssigneeBucketTaskManyToMany : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_BucketTasks_Assignees_AssigneeId",
            table: "BucketTask");

        migrationBuilder.DropIndex(
            name: "IX_BucketTasks_AssigneeId",
            table: "BucketTask");

        migrationBuilder.DropColumn(
            name: "AssigneeId",
            table: "BucketTask");

        migrationBuilder.CreateTable(
            name: "AssigneeBucketTask",
            columns: table => new
            {
                AssigneesId = table.Column<int>(type: "int", nullable: false),
                BucketTasksId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AssigneeBucketTask", x => new { x.AssigneesId, x.BucketTasksId });
                table.ForeignKey(
                    name: "FK_AssigneeBucketTask_Assignees_AssigneesId",
                    column: x => x.AssigneesId,
                    principalTable: "Assignee",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_AssigneeBucketTask_BucketTasks_BucketTasksId",
                    column: x => x.BucketTasksId,
                    principalTable: "BucketTask",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_AssigneeBucketTask_BucketTasksId",
            table: "AssigneeBucketTask",
            column: "BucketTasksId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "AssigneeBucketTask");

        migrationBuilder.AddColumn<int>(
            name: "AssigneeId",
            table: "BucketTask",
            type: "int",
            nullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_BucketTasks_AssigneeId",
            table: "BucketTask",
            column: "AssigneeId");

        migrationBuilder.AddForeignKey(
            name: "FK_BucketTasks_Assignees_AssigneeId",
            table: "BucketTask",
            column: "AssigneeId",
            principalTable: "Assignee",
            principalColumn: "Id");
    }
}
