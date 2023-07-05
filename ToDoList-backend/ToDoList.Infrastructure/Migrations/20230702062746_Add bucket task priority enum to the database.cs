using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    public partial class Addbuckettaskpriorityenumtothedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskPriority",
                table: "BucketTasks",
                newName: "BucketTaskPriorityId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BucketColor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BucketCategory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "BucketTaskPriority",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketTaskPriority", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BucketTaskPriority",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "High" });

            migrationBuilder.InsertData(
                table: "BucketTaskPriority",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Normal" });

            migrationBuilder.InsertData(
                table: "BucketTaskPriority",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Low" });

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "BucketTaskPriorityId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "BucketTaskPriorityId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "BucketTaskPriorityId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "BucketTaskPriorityId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "BucketTaskPriorityId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "BucketTaskPriorityId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_BucketTasks_BucketTaskPriorityId",
                table: "BucketTasks",
                column: "BucketTaskPriorityId");

            migrationBuilder.AddForeignKey(
                name: "FK_BucketTasks_BucketTaskPriority_BucketTaskPriorityId",
                table: "BucketTasks",
                column: "BucketTaskPriorityId",
                principalTable: "BucketTaskPriority",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BucketTasks_BucketTaskPriority_BucketTaskPriorityId",
                table: "BucketTasks");

            migrationBuilder.DropTable(
                name: "BucketTaskPriority");

            migrationBuilder.DropIndex(
                name: "IX_BucketTasks_BucketTaskPriorityId",
                table: "BucketTasks");

            migrationBuilder.RenameColumn(
                name: "BucketTaskPriorityId",
                table: "BucketTasks",
                newName: "TaskPriority");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BucketColor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BucketCategory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TaskPriority",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TaskPriority",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TaskPriority",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "TaskPriority",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "TaskPriority",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "TaskPriority",
                value: 0);
        }
    }
}
