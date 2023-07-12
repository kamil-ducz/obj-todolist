using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    public partial class Addbuckettaskassignee1nrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssigneeId",
                table: "BucketTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "AssigneeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "AssigneeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "AssigneeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "AssigneeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "AssigneeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "AssigneeId",
                value: 6);

            migrationBuilder.CreateIndex(
                name: "IX_BucketTasks_AssigneeId",
                table: "BucketTasks",
                column: "AssigneeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BucketTasks_Assignees_AssigneeId",
                table: "BucketTasks",
                column: "AssigneeId",
                principalTable: "Assignees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BucketTasks_Assignees_AssigneeId",
                table: "BucketTasks");

            migrationBuilder.DropIndex(
                name: "IX_BucketTasks_AssigneeId",
                table: "BucketTasks");

            migrationBuilder.DropColumn(
                name: "AssigneeId",
                table: "BucketTasks");
        }
    }
}
