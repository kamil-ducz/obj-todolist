using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    public partial class Changefrompluraltosingular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssigneesBucketTasks");

            migrationBuilder.DropTable(
                name: "Assignees");

            migrationBuilder.DropTable(
                name: "BucketTasks");

            migrationBuilder.DropTable(
                name: "Buckets");

            migrationBuilder.CreateTable(
                name: "Assignee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bucket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BucketCategoryId = table.Column<int>(type: "int", nullable: false),
                    BucketColorId = table.Column<int>(type: "int", nullable: false),
                    MaxAmountOfTasks = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bucket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bucket_BucketCategory_BucketCategoryId",
                        column: x => x.BucketCategoryId,
                        principalTable: "BucketCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bucket_BucketColor_BucketColorId",
                        column: x => x.BucketColorId,
                        principalTable: "BucketColor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BucketTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BucketTaskStateId = table.Column<int>(type: "int", nullable: false),
                    BucketTaskPriorityId = table.Column<int>(type: "int", nullable: false),
                    BucketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BucketTask_Bucket_BucketId",
                        column: x => x.BucketId,
                        principalTable: "Bucket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BucketTask_BucketTaskPriority_BucketTaskPriorityId",
                        column: x => x.BucketTaskPriorityId,
                        principalTable: "BucketTaskPriority",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BucketTask_BucketTaskState_BucketTaskStateId",
                        column: x => x.BucketTaskStateId,
                        principalTable: "BucketTaskState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssigneeBucketTask",
                columns: table => new
                {
                    AssigneeId = table.Column<int>(type: "int", nullable: false),
                    BucketTaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssigneeBucketTask", x => new { x.AssigneeId, x.BucketTaskId });
                    table.ForeignKey(
                        name: "FK_AssigneeBucketTask_Assignee_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "Assignee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssigneeBucketTask_BucketTask_BucketTaskId",
                        column: x => x.BucketTaskId,
                        principalTable: "BucketTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Assignee",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "John Doe" });

            migrationBuilder.InsertData(
                table: "Bucket",
                columns: new[] { "Id", "BucketCategoryId", "BucketColorId", "Description", "IsActive", "MaxAmountOfTasks", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1, null, true, 15, "Objectivity" },
                    { 2, 2, 2, null, true, 15, "Kitchen" },
                    { 3, 3, 3, null, true, 15, "Gym" }
                });

            migrationBuilder.InsertData(
                table: "BucketTask",
                columns: new[] { "Id", "BucketId", "BucketTaskPriorityId", "BucketTaskStateId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, null, "1:1 leader" },
                    { 2, 1, 2, 2, null, "Organize desk" },
                    { 3, 2, 3, 3, null, "Water plants" },
                    { 4, 2, 1, 4, null, "Clean bedroom" },
                    { 5, 3, 2, 3, null, "Organize diet" },
                    { 6, 3, 3, 2, null, "Training plan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssigneeBucketTask_BucketTaskId",
                table: "AssigneeBucketTask",
                column: "BucketTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Bucket_BucketCategoryId",
                table: "Bucket",
                column: "BucketCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Bucket_BucketColorId",
                table: "Bucket",
                column: "BucketColorId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketTask_BucketId",
                table: "BucketTask",
                column: "BucketId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketTask_BucketTaskPriorityId",
                table: "BucketTask",
                column: "BucketTaskPriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketTask_BucketTaskStateId",
                table: "BucketTask",
                column: "BucketTaskStateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssigneeBucketTask");

            migrationBuilder.DropTable(
                name: "Assignee");

            migrationBuilder.DropTable(
                name: "BucketTask");

            migrationBuilder.DropTable(
                name: "Bucket");

            migrationBuilder.CreateTable(
                name: "Assignees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buckets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BucketCategoryId = table.Column<int>(type: "int", nullable: false),
                    BucketColorId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MaxAmountOfTasks = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buckets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buckets_BucketCategory_BucketCategoryId",
                        column: x => x.BucketCategoryId,
                        principalTable: "BucketCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buckets_BucketColor_BucketColorId",
                        column: x => x.BucketColorId,
                        principalTable: "BucketColor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BucketTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BucketTaskPriorityId = table.Column<int>(type: "int", nullable: false),
                    BucketTaskStateId = table.Column<int>(type: "int", nullable: false),
                    BucketsId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BucketTasks_Buckets_BucketsId",
                        column: x => x.BucketsId,
                        principalTable: "Buckets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BucketTasks_BucketTaskPriority_BucketTaskPriorityId",
                        column: x => x.BucketTaskPriorityId,
                        principalTable: "BucketTaskPriority",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BucketTasks_BucketTaskState_BucketTaskStateId",
                        column: x => x.BucketTaskStateId,
                        principalTable: "BucketTaskState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssigneesBucketTasks",
                columns: table => new
                {
                    AssigneesId = table.Column<int>(type: "int", nullable: false),
                    BucketTasksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssigneesBucketTasks", x => new { x.AssigneesId, x.BucketTasksId });
                    table.ForeignKey(
                        name: "FK_AssigneesBucketTasks_Assignees_AssigneesId",
                        column: x => x.AssigneesId,
                        principalTable: "Assignees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssigneesBucketTasks_BucketTasks_BucketTasksId",
                        column: x => x.BucketTasksId,
                        principalTable: "BucketTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Assignees",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "John Doe" });

            migrationBuilder.InsertData(
                table: "Buckets",
                columns: new[] { "Id", "BucketCategoryId", "BucketColorId", "Description", "IsActive", "MaxAmountOfTasks", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1, null, true, 15, "Objectivity" },
                    { 2, 2, 2, null, true, 15, "Kitchen" },
                    { 3, 3, 3, null, true, 15, "Gym" }
                });

            migrationBuilder.InsertData(
                table: "BucketTasks",
                columns: new[] { "Id", "BucketTaskPriorityId", "BucketTaskStateId", "BucketsId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, null, "1:1 leader" },
                    { 2, 2, 2, 1, null, "Organize desk" },
                    { 3, 3, 3, 2, null, "Water plants" },
                    { 4, 1, 4, 2, null, "Clean bedroom" },
                    { 5, 2, 3, 3, null, "Organize diet" },
                    { 6, 3, 2, 3, null, "Training plan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssigneesBucketTasks_BucketTasksId",
                table: "AssigneesBucketTasks",
                column: "BucketTasksId");

            migrationBuilder.CreateIndex(
                name: "IX_Buckets_BucketCategoryId",
                table: "Buckets",
                column: "BucketCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Buckets_BucketColorId",
                table: "Buckets",
                column: "BucketColorId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketTasks_BucketsId",
                table: "BucketTasks",
                column: "BucketsId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketTasks_BucketTaskPriorityId",
                table: "BucketTasks",
                column: "BucketTaskPriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_BucketTasks_BucketTaskStateId",
                table: "BucketTasks",
                column: "BucketTaskStateId");
        }
    }
}
