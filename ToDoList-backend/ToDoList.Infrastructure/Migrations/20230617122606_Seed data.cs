using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations;

public partial class Seeddata : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_BucketTasks_Buckets_BucketId",
            table: "BucketTasks");

        migrationBuilder.AlterColumn<int>(
            name: "BucketId",
            table: "BucketTasks",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.InsertData(
            table: "Assignees",
            columns: new[] { "Id", "Name" },
            values: new object[] { 1, "John Doe" });

        migrationBuilder.InsertData(
            table: "Buckets",
            columns: new[] { "Id", "BucketColor", "Category", "Description", "IsActive", "MaxAmountOfTasks", "Name" },
            values: new object[,]
            {
                { 1, 0, 0, null, true, 0, "Work" },
                { 2, 0, 0, null, true, 0, "Home" },
                { 3, 0, 0, null, true, 0, "Hobby" }
            });

        migrationBuilder.InsertData(
            table: "Stats",
            columns: new[] { "Id", "AssigneeId", "Cancelled", "Completed", "InProgress", "ToDo" },
            values: new object[] { 1, null, 0m, 0m, 0m, 0m });

        migrationBuilder.InsertData(
            table: "BucketTasks",
            columns: new[] { "Id", "BucketId", "Description", "Name", "TaskPriority", "TaskState" },
            values: new object[,]
            {
                { 1, 1, null, "Speak to manager", 0, 0 },
                { 2, 1, null, "Organize desk", 0, 1 },
                { 3, 2, null, "Water plants", 0, 3 },
                { 4, 2, null, "Clean bedroom", 0, 2 },
                { 5, 3, null, "Organize diet", 0, 2 },
                { 6, 3, null, "Update training plan", 0, 1 }
            });

        migrationBuilder.AddForeignKey(
            name: "FK_BucketTasks_Buckets_BucketId",
            table: "BucketTasks",
            column: "BucketId",
            principalTable: "Buckets",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_BucketTasks_Buckets_BucketId",
            table: "BucketTasks");

        migrationBuilder.DeleteData(
            table: "Assignees",
            keyColumn: "Id",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "BucketTasks",
            keyColumn: "Id",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "BucketTasks",
            keyColumn: "Id",
            keyValue: 2);

        migrationBuilder.DeleteData(
            table: "BucketTasks",
            keyColumn: "Id",
            keyValue: 3);

        migrationBuilder.DeleteData(
            table: "BucketTasks",
            keyColumn: "Id",
            keyValue: 4);

        migrationBuilder.DeleteData(
            table: "BucketTasks",
            keyColumn: "Id",
            keyValue: 5);

        migrationBuilder.DeleteData(
            table: "BucketTasks",
            keyColumn: "Id",
            keyValue: 6);

        migrationBuilder.DeleteData(
            table: "Stats",
            keyColumn: "Id",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "Buckets",
            keyColumn: "Id",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "Buckets",
            keyColumn: "Id",
            keyValue: 2);

        migrationBuilder.DeleteData(
            table: "Buckets",
            keyColumn: "Id",
            keyValue: 3);

        migrationBuilder.AlterColumn<int>(
            name: "BucketId",
            table: "BucketTasks",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.AddForeignKey(
            name: "FK_BucketTasks_Buckets_BucketId",
            table: "BucketTasks",
            column: "BucketId",
            principalTable: "Buckets",
            principalColumn: "Id");
    }
}
