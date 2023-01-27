using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    public partial class StatsFixPercentColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PercentOfTasksToDo",
                table: "Stats",
                type: "decimal(3,0)",
                precision: 3,
                scale: 0,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldPrecision: 3,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "PercentOfTasksInProgress",
                table: "Stats",
                type: "decimal(3,0)",
                precision: 3,
                scale: 0,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldPrecision: 3,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "PercentOfTasksCompleted",
                table: "Stats",
                type: "decimal(3,0)",
                precision: 3,
                scale: 0,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldPrecision: 3,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "PercentOfTasksCancelled",
                table: "Stats",
                type: "decimal(3,0)",
                precision: 3,
                scale: 0,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldPrecision: 3,
                oldScale: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PercentOfTasksToDo",
                table: "Stats",
                type: "decimal(3,2)",
                precision: 3,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,0)",
                oldPrecision: 3,
                oldScale: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "PercentOfTasksInProgress",
                table: "Stats",
                type: "decimal(3,2)",
                precision: 3,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,0)",
                oldPrecision: 3,
                oldScale: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "PercentOfTasksCompleted",
                table: "Stats",
                type: "decimal(3,2)",
                precision: 3,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,0)",
                oldPrecision: 3,
                oldScale: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "PercentOfTasksCancelled",
                table: "Stats",
                type: "decimal(3,2)",
                precision: 3,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,0)",
                oldPrecision: 3,
                oldScale: 0);
        }
    }
}
