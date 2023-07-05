using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    public partial class Bucketcolorenumaddedfordb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buckets_Category_BucketCategoryId",
                table: "Buckets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "BucketCategory");

            migrationBuilder.RenameColumn(
                name: "BucketColor",
                table: "Buckets",
                newName: "BucketColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BucketCategory",
                table: "BucketCategory",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BucketColor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketColor", x => x.Id);
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

            migrationBuilder.UpdateData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 1,
                column: "BucketColorId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 2,
                column: "BucketColorId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 3,
                column: "BucketColorId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Buckets_BucketColorId",
                table: "Buckets",
                column: "BucketColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buckets_BucketCategory_BucketCategoryId",
                table: "Buckets",
                column: "BucketCategoryId",
                principalTable: "BucketCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buckets_BucketColor_BucketColorId",
                table: "Buckets",
                column: "BucketColorId",
                principalTable: "BucketColor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buckets_BucketCategory_BucketCategoryId",
                table: "Buckets");

            migrationBuilder.DropForeignKey(
                name: "FK_Buckets_BucketColor_BucketColorId",
                table: "Buckets");

            migrationBuilder.DropTable(
                name: "BucketColor");

            migrationBuilder.DropIndex(
                name: "IX_Buckets_BucketColorId",
                table: "Buckets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BucketCategory",
                table: "BucketCategory");

            migrationBuilder.RenameTable(
                name: "BucketCategory",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "BucketColorId",
                table: "Buckets",
                newName: "BucketColor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 1,
                column: "BucketColor",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 2,
                column: "BucketColor",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 3,
                column: "BucketColor",
                value: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Buckets_Category_BucketCategoryId",
                table: "Buckets",
                column: "BucketCategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
