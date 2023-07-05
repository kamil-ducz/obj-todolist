using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    public partial class Fixseeddataforvalidators : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "1:1 leader");

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Training plan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Speak to manager");

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Update training plan");
        }
    }
}
