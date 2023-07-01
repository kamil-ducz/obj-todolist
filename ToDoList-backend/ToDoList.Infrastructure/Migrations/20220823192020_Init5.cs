using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations;

public partial class Init5 : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_BucketTasks_Buckets_BucketId",
            table: "BucketTask");

        migrationBuilder.DropIndex(
            name: "IX_Assignees_StatsId",
            table: "Assignee");

        migrationBuilder.DropColumn(
            name: "AsigneeId",
            table: "Stats");

        migrationBuilder.AlterColumn<int>(
            name: "BucketId",
            table: "BucketTask",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        migrationBuilder.CreateIndex(
            name: "IX_Assignees_StatsId",
            table: "Assignee",
            column: "StatsId");

        migrationBuilder.AddForeignKey(
            name: "FK_BucketTasks_Buckets_BucketId",
            table: "BucketTask",
            column: "BucketId",
            principalTable: "Bucket",
            principalColumn: "Id");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_BucketTasks_Buckets_BucketId",
            table: "BucketTask");

        migrationBuilder.DropIndex(
            name: "IX_Assignees_StatsId",
            table: "Assignee");

        migrationBuilder.AddColumn<int>(
            name: "AsigneeId",
            table: "Stats",
            type: "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AlterColumn<int>(
            name: "BucketId",
            table: "BucketTask",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_Assignees_StatsId",
            table: "Assignee",
            column: "StatsId",
            unique: true);

        migrationBuilder.AddForeignKey(
            name: "FK_BucketTasks_Buckets_BucketId",
            table: "BucketTask",
            column: "BucketId",
            principalTable: "Bucket",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
