using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations;

public partial class SetMaxAmountOfTasksforbucketsseed : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.UpdateData(
            table: "Bucket",
            keyColumn: "Id",
            keyValue: 1,
            column: "MaxAmountOfTasks",
            value: 15);

        migrationBuilder.UpdateData(
            table: "Bucket",
            keyColumn: "Id",
            keyValue: 2,
            column: "MaxAmountOfTasks",
            value: 15);

        migrationBuilder.UpdateData(
            table: "Bucket",
            keyColumn: "Id",
            keyValue: 3,
            column: "MaxAmountOfTasks",
            value: 15);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.UpdateData(
            table: "Bucket",
            keyColumn: "Id",
            keyValue: 1,
            column: "MaxAmountOfTasks",
            value: 0);

        migrationBuilder.UpdateData(
            table: "Bucket",
            keyColumn: "Id",
            keyValue: 2,
            column: "MaxAmountOfTasks",
            value: 0);

        migrationBuilder.UpdateData(
            table: "Bucket",
            keyColumn: "Id",
            keyValue: 3,
            column: "MaxAmountOfTasks",
            value: 0);
    }
}
