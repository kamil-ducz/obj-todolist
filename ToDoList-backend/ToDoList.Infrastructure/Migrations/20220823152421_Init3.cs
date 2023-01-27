using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignees_Stats_StatsId",
                table: "Assignees");

            migrationBuilder.DropIndex(
                name: "IX_Assignees_StatsId",
                table: "Assignees");

            migrationBuilder.AlterColumn<int>(
                name: "StatsId",
                table: "Assignees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Assignees_StatsId",
                table: "Assignees",
                column: "StatsId",
                unique: true,
                filter: "[StatsId] IS NOT NULL");

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

            migrationBuilder.DropIndex(
                name: "IX_Assignees_StatsId",
                table: "Assignees");

            migrationBuilder.AlterColumn<int>(
                name: "StatsId",
                table: "Assignees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignees_StatsId",
                table: "Assignees",
                column: "StatsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignees_Stats_StatsId",
                table: "Assignees",
                column: "StatsId",
                principalTable: "Stats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
