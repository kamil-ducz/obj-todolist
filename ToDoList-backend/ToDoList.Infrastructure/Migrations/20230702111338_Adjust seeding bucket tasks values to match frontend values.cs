using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    public partial class Adjustseedingbuckettasksvaluestomatchfrontendvalues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BucketTaskPriority",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Medium");

            migrationBuilder.UpdateData(
                table: "BucketTaskState",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "To do");

            migrationBuilder.UpdateData(
                table: "BucketTaskState",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "In progress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BucketTaskPriority",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Normal");

            migrationBuilder.UpdateData(
                table: "BucketTaskState",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "ToDo");

            migrationBuilder.UpdateData(
                table: "BucketTaskState",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "InProgress");
        }
    }
}
