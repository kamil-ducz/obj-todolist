using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    public partial class FixenumsFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BucketTasks_BucketTaskStates_BucketTaskStateId1",
                table: "BucketTasks");

            migrationBuilder.DropIndex(
                name: "IX_BucketTasks_BucketTaskStateId1",
                table: "BucketTasks");

            migrationBuilder.DropColumn(
                name: "BucketTaskStateId1",
                table: "BucketTasks");

            migrationBuilder.CreateIndex(
                name: "IX_BucketTasks_BucketTaskStateId",
                table: "BucketTasks",
                column: "BucketTaskStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_BucketTasks_BucketTaskStates_BucketTaskStateId",
                table: "BucketTasks",
                column: "BucketTaskStateId",
                principalTable: "BucketTaskStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BucketTasks_BucketTaskStates_BucketTaskStateId",
                table: "BucketTasks");

            migrationBuilder.DropIndex(
                name: "IX_BucketTasks_BucketTaskStateId",
                table: "BucketTasks");

            migrationBuilder.AddColumn<int>(
                name: "BucketTaskStateId1",
                table: "BucketTasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BucketTasks_BucketTaskStateId1",
                table: "BucketTasks",
                column: "BucketTaskStateId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BucketTasks_BucketTaskStates_BucketTaskStateId1",
                table: "BucketTasks",
                column: "BucketTaskStateId1",
                principalTable: "BucketTaskStates",
                principalColumn: "Id");
        }
    }
}
