using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    public partial class BucketchangedtoBucketsfornamespaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BucketTasks_Buckets_BucketId",
                table: "BucketTasks");

            migrationBuilder.RenameColumn(
                name: "BucketId",
                table: "BucketTasks",
                newName: "BucketsId");

            migrationBuilder.RenameIndex(
                name: "IX_BucketTasks_BucketId",
                table: "BucketTasks",
                newName: "IX_BucketTasks_BucketsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BucketTasks_Buckets_BucketsId",
                table: "BucketTasks",
                column: "BucketsId",
                principalTable: "Buckets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BucketTasks_Buckets_BucketsId",
                table: "BucketTasks");

            migrationBuilder.RenameColumn(
                name: "BucketsId",
                table: "BucketTasks",
                newName: "BucketId");

            migrationBuilder.RenameIndex(
                name: "IX_BucketTasks_BucketsId",
                table: "BucketTasks",
                newName: "IX_BucketTasks_BucketId");

            migrationBuilder.AddForeignKey(
                name: "FK_BucketTasks_Buckets_BucketId",
                table: "BucketTasks",
                column: "BucketId",
                principalTable: "Buckets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
