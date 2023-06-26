using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations;

public partial class StatsIdAllowNull : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Assignees_Stats_StatsId",
            table: "Assignees");

        migrationBuilder.AddForeignKey(
            name: "FK_Assignees_Stats_StatsId",
            table: "Assignees",
            column: "StatsId",
            principalTable: "Stats",
            principalColumn: "Id");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Assignees_Stats_StatsId",
            table: "Assignees");

        migrationBuilder.AddForeignKey(
            name: "FK_Assignees_Stats_StatsId",
            table: "Assignees",
            column: "StatsId",
            principalTable: "Stats",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
