using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations;

public partial class Init1 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Bucket",
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
            name: "Assignee",
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
            name: "BucketTask",
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
                    principalTable: "Assignee",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_BucketTasks_Buckets_BucketId",
                    column: x => x.BucketId,
                    principalTable: "Bucket",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Assignees_StatsId",
            table: "Assignee",
            column: "StatsId",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_BucketTasks_AssigneeId",
            table: "BucketTask",
            column: "AssigneeId");

        migrationBuilder.CreateIndex(
            name: "IX_BucketTasks_BucketId",
            table: "BucketTask",
            column: "BucketId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "BucketTask");

        migrationBuilder.DropTable(
            name: "Assignee");

        migrationBuilder.DropTable(
            name: "Bucket");

        migrationBuilder.DropTable(
            name: "Stats");
    }
}
