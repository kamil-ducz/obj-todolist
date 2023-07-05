using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    public partial class Addbuckettaskstateenumtothedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskState",
                table: "BucketTasks",
                newName: "BucketTaskStateId");

            migrationBuilder.CreateTable(
                name: "BucketTaskState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketTaskState", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BucketTaskState",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ToDo" },
                    { 2, "InProgress" },
                    { 3, "Done" },
                    { 4, "Cancelled" }
                });

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "BucketTaskStateId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "BucketTaskStateId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "BucketTaskStateId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "BucketTaskStateId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "BucketTaskStateId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_BucketTasks_BucketTaskStateId",
                table: "BucketTasks",
                column: "BucketTaskStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_BucketTasks_BucketTaskState_BucketTaskStateId",
                table: "BucketTasks",
                column: "BucketTaskStateId",
                principalTable: "BucketTaskState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BucketTasks_BucketTaskState_BucketTaskStateId",
                table: "BucketTasks");

            migrationBuilder.DropTable(
                name: "BucketTaskState");

            migrationBuilder.DropIndex(
                name: "IX_BucketTasks_BucketTaskStateId",
                table: "BucketTasks");

            migrationBuilder.RenameColumn(
                name: "BucketTaskStateId",
                table: "BucketTasks",
                newName: "TaskState");

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TaskState",
                value: 0);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TaskState",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "TaskState",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "TaskState",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "TaskState",
                value: 1);
        }
    }
}
