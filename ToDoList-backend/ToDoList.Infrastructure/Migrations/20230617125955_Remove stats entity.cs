using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations;

public partial class Removestatsentity : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Stats");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Stats",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                AssigneeId = table.Column<int>(type: "int", nullable: true),
                Cancelled = table.Column<decimal>(type: "decimal(3,0)", precision: 3, nullable: false),
                Completed = table.Column<decimal>(type: "decimal(3,0)", precision: 3, nullable: false),
                InProgress = table.Column<decimal>(type: "decimal(3,0)", precision: 3, nullable: false),
                ToDo = table.Column<decimal>(type: "decimal(3,0)", precision: 3, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Stats", x => x.Id);
                table.ForeignKey(
                    name: "FK_Stats_Assignees_AssigneeId",
                    column: x => x.AssigneeId,
                    principalTable: "Assignees",
                    principalColumn: "Id");
            });

        migrationBuilder.InsertData(
            table: "Stats",
            columns: new[] { "Id", "AssigneeId", "Cancelled", "Completed", "InProgress", "ToDo" },
            values: new object[] { 1, null, 0m, 0m, 0m, 0m });

        migrationBuilder.CreateIndex(
            name: "IX_Stats_AssigneeId",
            table: "Stats",
            column: "AssigneeId");
    }
}
