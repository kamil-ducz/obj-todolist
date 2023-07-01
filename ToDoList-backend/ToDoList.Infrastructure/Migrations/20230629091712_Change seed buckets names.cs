using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    public partial class Changeseedbucketsnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bucket",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Objectivity");

            migrationBuilder.UpdateData(
                table: "Bucket",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Kitchen");

            migrationBuilder.UpdateData(
                table: "Bucket",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Gym");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bucket",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Work");

            migrationBuilder.UpdateData(
                table: "Bucket",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Home");

            migrationBuilder.UpdateData(
                table: "Bucket",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Hobby");
        }
    }
}
