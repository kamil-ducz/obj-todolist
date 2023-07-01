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
                table: "BucketTask");

            migrationBuilder.RenameColumn(
                name: "BucketId",
                table: "BucketTask",
                newName: "BucketsId");

            migrationBuilder.RenameIndex(
                name: "IX_BucketTasks_BucketId",
                table: "BucketTask",
                newName: "IX_BucketTasks_BucketsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BucketTasks_Buckets_BucketsId",
                table: "BucketTask",
                column: "BucketsId",
                principalTable: "Bucket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BucketTasks_Buckets_BucketsId",
                table: "BucketTask");

            migrationBuilder.RenameColumn(
                name: "BucketsId",
                table: "BucketTask",
                newName: "BucketId");

            migrationBuilder.RenameIndex(
                name: "IX_BucketTasks_BucketsId",
                table: "BucketTask",
                newName: "IX_BucketTasks_BucketId");

            migrationBuilder.AddForeignKey(
                name: "FK_BucketTasks_Buckets_BucketId",
                table: "BucketTask",
                column: "BucketId",
                principalTable: "Bucket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
