using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    public partial class AssigneechangedtoAssigneesfornamespaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssigneeBucketTask");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BucketTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Buckets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Assignees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AssigneesBucketTask",
                columns: table => new
                {
                    AssigneesId = table.Column<int>(type: "int", nullable: false),
                    BucketTasksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssigneesBucketTask", x => new { x.AssigneesId, x.BucketTasksId });
                    table.ForeignKey(
                        name: "FK_AssigneesBucketTask_Assignees_AssigneesId",
                        column: x => x.AssigneesId,
                        principalTable: "Assignees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssigneesBucketTask_BucketTasks_BucketTasksId",
                        column: x => x.BucketTasksId,
                        principalTable: "BucketTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssigneesBucketTask_BucketTasksId",
                table: "AssigneesBucketTask",
                column: "BucketTasksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssigneesBucketTask");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BucketTasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Buckets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Assignees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "AssigneeBucketTask",
                columns: table => new
                {
                    AssigneesId = table.Column<int>(type: "int", nullable: false),
                    BucketTasksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssigneeBucketTask", x => new { x.AssigneesId, x.BucketTasksId });
                    table.ForeignKey(
                        name: "FK_AssigneeBucketTask_Assignees_AssigneesId",
                        column: x => x.AssigneesId,
                        principalTable: "Assignees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssigneeBucketTask_BucketTasks_BucketTasksId",
                        column: x => x.BucketTasksId,
                        principalTable: "BucketTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssigneeBucketTask_BucketTasksId",
                table: "AssigneeBucketTask",
                column: "BucketTasksId");
        }
    }
}
