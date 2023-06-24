using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations;

public partial class Renamestatscolumns : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "PercentOfTasksCancelled",
            table: "Stats");

        migrationBuilder.DropColumn(
            name: "PercentOfTasksCompleted",
            table: "Stats");

        migrationBuilder.DropColumn(
            name: "PercentOfTasksInProgress",
            table: "Stats");

        migrationBuilder.DropColumn(
            name: "PercentOfTasksToDo",
            table: "Stats");

        migrationBuilder.AddColumn<decimal>(
            name: "Cancelled",
            table: "Stats",
            type: "decimal(3,0)",
            precision: 3,
            scale: 0,
            nullable: false,
            defaultValue: 0m);

        migrationBuilder.AddColumn<decimal>(
            name: "Completed",
            table: "Stats",
            type: "decimal(3,0)",
            precision: 3,
            scale: 0,
            nullable: false,
            defaultValue: 0m);

        migrationBuilder.AddColumn<decimal>(
            name: "InProgress",
            table: "Stats",
            type: "decimal(3,0)",
            precision: 3,
            scale: 0,
            nullable: false,
            defaultValue: 0m);

        migrationBuilder.AddColumn<decimal>(
            name: "ToDo",
            table: "Stats",
            type: "decimal(3,0)",
            precision: 3,
            scale: 0,
            nullable: false,
            defaultValue: 0m);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Cancelled",
            table: "Stats");

        migrationBuilder.DropColumn(
            name: "Completed",
            table: "Stats");

        migrationBuilder.DropColumn(
            name: "InProgress",
            table: "Stats");

        migrationBuilder.DropColumn(
            name: "ToDo",
            table: "Stats");

        migrationBuilder.AddColumn<decimal>(
            name: "PercentOfTasksCancelled",
            table: "Stats",
            type: "decimal(3,0)",
            precision: 3,
            nullable: false,
            defaultValue: 0m);

        migrationBuilder.AddColumn<decimal>(
            name: "PercentOfTasksCompleted",
            table: "Stats",
            type: "decimal(3,0)",
            precision: 3,
            nullable: false,
            defaultValue: 0m);

        migrationBuilder.AddColumn<decimal>(
            name: "PercentOfTasksInProgress",
            table: "Stats",
            type: "decimal(3,0)",
            precision: 3,
            nullable: false,
            defaultValue: 0m);

        migrationBuilder.AddColumn<decimal>(
            name: "PercentOfTasksToDo",
            table: "Stats",
            type: "decimal(3,0)",
            precision: 3,
            nullable: false,
            defaultValue: 0m);
    }
}
