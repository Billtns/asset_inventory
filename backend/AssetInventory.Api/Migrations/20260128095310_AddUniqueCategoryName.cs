using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetInventory.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueCategoryName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 16, 53, 10, 603, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 16, 53, 10, 603, DateTimeKind.Local).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 16, 53, 10, 603, DateTimeKind.Local).AddTicks(6980));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 28, 16, 53, 10, 603, DateTimeKind.Local).AddTicks(6980));

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryName",
                table: "Categories",
                column: "CategoryName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryName",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Categories",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 26, 14, 26, 42, 39, DateTimeKind.Local).AddTicks(7760));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 26, 14, 26, 42, 39, DateTimeKind.Local).AddTicks(7940));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 26, 14, 26, 42, 39, DateTimeKind.Local).AddTicks(7940));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 26, 14, 26, 42, 39, DateTimeKind.Local).AddTicks(7940));
        }
    }
}
