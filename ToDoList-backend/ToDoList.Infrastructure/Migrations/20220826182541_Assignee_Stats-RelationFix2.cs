using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations;

public partial class Assignee_StatsRelationFix2 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Assignees_Stats_StatsId",
            table: "Assignee");

        migrationBuilder.DropIndex(
            name: "IX_Assignees_StatsId",
            table: "Assignee");

        migrationBuilder.DropColumn(
            name: "StatsId",
            table: "Assignee");

        migrationBuilder.AddColumn<int>(
            name: "AssigneeId",
            table: "Stats",
            type: "int",
            nullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_Stats_AssigneeId",
            table: "Stats",
            column: "AssigneeId");

        migrationBuilder.AddForeignKey(
            name: "FK_Stats_Assignees_AssigneeId",
            table: "Stats",
            column: "AssigneeId",
            principalTable: "Assignee",
            principalColumn: "Id");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Stats_Assignees_AssigneeId",
            table: "Stats");

        migrationBuilder.DropIndex(
            name: "IX_Stats_AssigneeId",
            table: "Stats");

        migrationBuilder.DropColumn(
            name: "AssigneeId",
            table: "Stats");

        migrationBuilder.AddColumn<int>(
            name: "StatsId",
            table: "Assignee",
            type: "int",
            nullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_Assignees_StatsId",
            table: "Assignee",
            column: "StatsId");

        migrationBuilder.AddForeignKey(
            name: "FK_Assignees_Stats_StatsId",
            table: "Assignee",
            column: "StatsId",
            principalTable: "Stats",
            principalColumn: "Id");
    }
}
