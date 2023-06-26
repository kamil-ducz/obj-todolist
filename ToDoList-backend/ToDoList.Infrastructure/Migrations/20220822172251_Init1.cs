using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations;

public partial class Init1 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Buckets",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Category = table.Column<int>(type: "int", nullable: false),
                BucketColor = table.Column<int>(type: "int", nullable: false),
                MaxAmountOfTasks = table.Column<int>(type: "int", nullable: false),
                IsActive = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Buckets", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Stats",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                AsigneeId = table.Column<int>(type: "int", nullable: false),
                PercentOfTasksCompleted = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: false),
                PercentOfTasksToDo = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: false),
                PercentOfTasksInProgress = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: false),
                PercentOfTasksCancelled = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Stats", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Assignees",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                StatsId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Assignees", x => x.Id);
                table.ForeignKey(
                    name: "FK_Assignees_Stats_StatsId",
                    column: x => x.StatsId,
                    principalTable: "Stats",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "BucketTasks",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                BucketId = table.Column<int>(type: "int", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                TaskState = table.Column<int>(type: "int", nullable: false),
                TaskPriority = table.Column<int>(type: "int", nullable: false),
                AssigneeId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_BucketTasks", x => x.Id);
                table.ForeignKey(
                    name: "FK_BucketTasks_Assignees_AssigneeId",
                    column: x => x.AssigneeId,
                    principalTable: "Assignees",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_BucketTasks_Buckets_BucketId",
                    column: x => x.BucketId,
                    principalTable: "Buckets",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Assignees_StatsId",
            table: "Assignees",
            column: "StatsId",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_BucketTasks_AssigneeId",
            table: "BucketTasks",
            column: "AssigneeId");

        migrationBuilder.CreateIndex(
            name: "IX_BucketTasks_BucketId",
            table: "BucketTasks",
            column: "BucketId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "BucketTasks");

        migrationBuilder.DropTable(
            name: "Assignees");

        migrationBuilder.DropTable(
            name: "Buckets");

        migrationBuilder.DropTable(
            name: "Stats");
    }
}
