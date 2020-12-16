using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EssickFinalProject5.Migrations
{
    public partial class PostImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Create", "Image" },
                values: new object[] { new DateTime(2020, 12, 14, 16, 19, 6, 815, DateTimeKind.Local).AddTicks(8711), "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Create",
                value: new DateTime(2020, 12, 14, 14, 50, 40, 789, DateTimeKind.Local).AddTicks(4628));
        }
    }
}
