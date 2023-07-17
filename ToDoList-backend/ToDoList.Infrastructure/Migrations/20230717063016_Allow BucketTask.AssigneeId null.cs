using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    public partial class AllowBucketTaskAssigneeIdnull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BucketTasks_Assignees_AssigneeId",
                table: "BucketTasks");

            migrationBuilder.AlterColumn<int>(
                name: "AssigneeId",
                table: "BucketTasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BucketTasks_Assignees_AssigneeId",
                table: "BucketTasks",
                column: "AssigneeId",
                principalTable: "Assignees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BucketTasks_Assignees_AssigneeId",
                table: "BucketTasks");

            migrationBuilder.AlterColumn<int>(
                name: "AssigneeId",
                table: "BucketTasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BucketTasks_Assignees_AssigneeId",
                table: "BucketTasks",
                column: "AssigneeId",
                principalTable: "Assignees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
