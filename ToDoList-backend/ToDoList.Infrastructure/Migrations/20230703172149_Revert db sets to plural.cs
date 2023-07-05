using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    public partial class Revertdbsetstoplural : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssigneeBucketTask_Assignee_AssigneeId",
                table: "AssigneeBucketTask");

            migrationBuilder.DropForeignKey(
                name: "FK_AssigneeBucketTask_BucketTask_BucketTaskId",
                table: "AssigneeBucketTask");

            migrationBuilder.DropForeignKey(
                name: "FK_Bucket_BucketCategory_BucketCategoryId",
                table: "Bucket");

            migrationBuilder.DropForeignKey(
                name: "FK_Bucket_BucketColor_BucketColorId",
                table: "Bucket");

            migrationBuilder.DropForeignKey(
                name: "FK_BucketTask_Bucket_BucketId",
                table: "BucketTask");

            migrationBuilder.DropForeignKey(
                name: "FK_BucketTask_BucketTaskPriority_BucketTaskPriorityId",
                table: "BucketTask");

            migrationBuilder.DropForeignKey(
                name: "FK_BucketTask_BucketTaskState_BucketTaskStateId",
                table: "BucketTask");

            migrationBuilder.DropTable(
                name: "BucketCategory");

            migrationBuilder.DropTable(
                name: "BucketColor");

            migrationBuilder.DropTable(
                name: "BucketTaskPriority");

            migrationBuilder.DropTable(
                name: "BucketTaskState");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BucketTask",
                table: "BucketTask");

            migrationBuilder.DropIndex(
                name: "IX_BucketTask_BucketTaskStateId",
                table: "BucketTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bucket",
                table: "Bucket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignee",
                table: "Assignee");

            migrationBuilder.RenameTable(
                name: "BucketTask",
                newName: "BucketTasks");

            migrationBuilder.RenameTable(
                name: "Bucket",
                newName: "Buckets");

            migrationBuilder.RenameTable(
                name: "Assignee",
                newName: "Assignees");

            migrationBuilder.RenameIndex(
                name: "IX_BucketTask_BucketTaskPriorityId",
                table: "BucketTasks",
                newName: "IX_BucketTasks_BucketTaskPriorityId");

            migrationBuilder.RenameIndex(
                name: "IX_BucketTask_BucketId",
                table: "BucketTasks",
                newName: "IX_BucketTasks_BucketId");

            migrationBuilder.RenameIndex(
                name: "IX_Bucket_BucketColorId",
                table: "Buckets",
                newName: "IX_Buckets_BucketColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Bucket_BucketCategoryId",
                table: "Buckets",
                newName: "IX_Buckets_BucketCategoryId");

            migrationBuilder.AddColumn<int>(
                name: "BucketTaskStateId1",
                table: "BucketTasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BucketTasks",
                table: "BucketTasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buckets",
                table: "Buckets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignees",
                table: "Assignees",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BucketCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BucketColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BucketTaskPriorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketTaskPriorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BucketTaskStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketTaskStates", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BucketCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Work" },
                    { 2, "Home" },
                    { 3, "Hobby" }
                });

            migrationBuilder.InsertData(
                table: "BucketColors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Brown" },
                    { 2, "Red" },
                    { 3, "Yellow" },
                    { 4, "Blue" },
                    { 5, "White" },
                    { 6, "Green" }
                });

            migrationBuilder.InsertData(
                table: "BucketTaskPriorities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "High" },
                    { 2, "Medium" },
                    { 3, "Low" }
                });

            migrationBuilder.InsertData(
                table: "BucketTaskStates",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "To do" },
                    { 2, "In progress" },
                    { 3, "Done" },
                    { 4, "Cancelled" }
                });

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "BucketTaskStateId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "BucketTaskStateId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "BucketTaskPriorityId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BucketTaskPriorityId", "BucketTaskStateId" },
                values: new object[] { 1, 4 });

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BucketTaskPriorityId", "BucketTaskStateId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "BucketTasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BucketTaskPriorityId", "BucketTaskStateId" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 1,
                column: "BucketCategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BucketCategoryId", "BucketColorId" },
                values: new object[] { 2, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_BucketTasks_BucketTaskStateId1",
                table: "BucketTasks",
                column: "BucketTaskStateId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AssigneeBucketTask_Assignees_AssigneeId",
                table: "AssigneeBucketTask",
                column: "AssigneeId",
                principalTable: "Assignees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssigneeBucketTask_BucketTasks_BucketTaskId",
                table: "AssigneeBucketTask",
                column: "BucketTaskId",
                principalTable: "BucketTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buckets_BucketCategories_BucketCategoryId",
                table: "Buckets",
                column: "BucketCategoryId",
                principalTable: "BucketCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buckets_BucketColors_BucketColorId",
                table: "Buckets",
                column: "BucketColorId",
                principalTable: "BucketColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BucketTasks_Buckets_BucketId",
                table: "BucketTasks",
                column: "BucketId",
                principalTable: "Buckets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BucketTasks_BucketTaskPriorities_BucketTaskPriorityId",
                table: "BucketTasks",
                column: "BucketTaskPriorityId",
                principalTable: "BucketTaskPriorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BucketTasks_BucketTaskStates_BucketTaskStateId1",
                table: "BucketTasks",
                column: "BucketTaskStateId1",
                principalTable: "BucketTaskStates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssigneeBucketTask_Assignees_AssigneeId",
                table: "AssigneeBucketTask");

            migrationBuilder.DropForeignKey(
                name: "FK_AssigneeBucketTask_BucketTasks_BucketTaskId",
                table: "AssigneeBucketTask");

            migrationBuilder.DropForeignKey(
                name: "FK_Buckets_BucketCategories_BucketCategoryId",
                table: "Buckets");

            migrationBuilder.DropForeignKey(
                name: "FK_Buckets_BucketColors_BucketColorId",
                table: "Buckets");

            migrationBuilder.DropForeignKey(
                name: "FK_BucketTasks_Buckets_BucketId",
                table: "BucketTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_BucketTasks_BucketTaskPriorities_BucketTaskPriorityId",
                table: "BucketTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_BucketTasks_BucketTaskStates_BucketTaskStateId1",
                table: "BucketTasks");

            migrationBuilder.DropTable(
                name: "BucketCategories");

            migrationBuilder.DropTable(
                name: "BucketColors");

            migrationBuilder.DropTable(
                name: "BucketTaskPriorities");

            migrationBuilder.DropTable(
                name: "BucketTaskStates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BucketTasks",
                table: "BucketTasks");

            migrationBuilder.DropIndex(
                name: "IX_BucketTasks_BucketTaskStateId1",
                table: "BucketTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buckets",
                table: "Buckets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignees",
                table: "Assignees");

            migrationBuilder.DropColumn(
                name: "BucketTaskStateId1",
                table: "BucketTasks");

            migrationBuilder.RenameTable(
                name: "BucketTasks",
                newName: "BucketTask");

            migrationBuilder.RenameTable(
                name: "Buckets",
                newName: "Bucket");

            migrationBuilder.RenameTable(
                name: "Assignees",
                newName: "Assignee");

            migrationBuilder.RenameIndex(
                name: "IX_BucketTasks_BucketTaskPriorityId",
                table: "BucketTask",
                newName: "IX_BucketTask_BucketTaskPriorityId");

            migrationBuilder.RenameIndex(
                name: "IX_BucketTasks_BucketId",
                table: "BucketTask",
                newName: "IX_BucketTask_BucketId");

            migrationBuilder.RenameIndex(
                name: "IX_Buckets_BucketColorId",
                table: "Bucket",
                newName: "IX_Bucket_BucketColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Buckets_BucketCategoryId",
                table: "Bucket",
                newName: "IX_Bucket_BucketCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BucketTask",
                table: "BucketTask",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bucket",
                table: "Bucket",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignee",
                table: "Assignee",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BucketCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BucketColor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketColor", x => x.Id);
                });

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
                table: "BucketCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Work" },
                    { 2, "Home" },
                    { 3, "Hobby" }
                });

            migrationBuilder.InsertData(
                table: "BucketColor",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Brown" },
                    { 2, "Red" },
                    { 3, "Yellow" },
                    { 4, "Blue" },
                    { 5, "White" },
                    { 6, "Green" }
                });

            migrationBuilder.InsertData(
                table: "BucketTaskPriority",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "High" },
                    { 2, "Medium" },
                    { 3, "Low" }
                });

            migrationBuilder.InsertData(
                table: "BucketTaskState",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "To do" },
                    { 2, "In progress" },
                    { 3, "Done" },
                    { 4, "Cancelled" }
                });

            migrationBuilder.UpdateData(
                table: "Bucket",
                keyColumn: "Id",
                keyValue: 1,
                column: "BucketCategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Bucket",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BucketCategoryId", "BucketColorId" },
                values: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "BucketTask",
                keyColumn: "Id",
                keyValue: 1,
                column: "BucketTaskPriorityId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BucketTask",
                keyColumn: "Id",
                keyValue: 2,
                column: "BucketTaskStateId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BucketTask",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BucketTaskPriorityId", "BucketTaskStateId" },
                values: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "BucketTask",
                keyColumn: "Id",
                keyValue: 4,
                column: "BucketTaskStateId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "BucketTask",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BucketTaskPriorityId", "BucketTaskStateId" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "BucketTask",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BucketTaskPriorityId", "BucketTaskStateId" },
                values: new object[] { 3, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_BucketTask_BucketTaskStateId",
                table: "BucketTask",
                column: "BucketTaskStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssigneeBucketTask_Assignee_AssigneeId",
                table: "AssigneeBucketTask",
                column: "AssigneeId",
                principalTable: "Assignee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssigneeBucketTask_BucketTask_BucketTaskId",
                table: "AssigneeBucketTask",
                column: "BucketTaskId",
                principalTable: "BucketTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bucket_BucketCategory_BucketCategoryId",
                table: "Bucket",
                column: "BucketCategoryId",
                principalTable: "BucketCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bucket_BucketColor_BucketColorId",
                table: "Bucket",
                column: "BucketColorId",
                principalTable: "BucketColor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BucketTask_Bucket_BucketId",
                table: "BucketTask",
                column: "BucketId",
                principalTable: "Bucket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BucketTask_BucketTaskPriority_BucketTaskPriorityId",
                table: "BucketTask",
                column: "BucketTaskPriorityId",
                principalTable: "BucketTaskPriority",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BucketTask_BucketTaskState_BucketTaskStateId",
                table: "BucketTask",
                column: "BucketTaskStateId",
                principalTable: "BucketTaskState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
