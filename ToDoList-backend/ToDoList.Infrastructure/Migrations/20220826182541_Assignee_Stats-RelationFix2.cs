using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    public partial class Assignee_StatsRelationFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignees_Stats_StatsId",
                table: "Assignees");

            migrationBuilder.DropIndex(
                name: "IX_Assignees_StatsId",
                table: "Assignees");

            migrationBuilder.DropColumn(
                name: "StatsId",
                table: "Assignees");

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
                principalTable: "Assignees",
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
                table: "Assignees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignees_StatsId",
                table: "Assignees",
                column: "StatsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignees_Stats_StatsId",
                table: "Assignees",
                column: "StatsId",
                principalTable: "Stats",
                principalColumn: "Id");
        }
    }
}
