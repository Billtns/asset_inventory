using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetInventory.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnUpdateBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 26, 8, 34, 4, 185, DateTimeKind.Local).AddTicks(2740));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 26, 8, 34, 4, 185, DateTimeKind.Local).AddTicks(2920));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 26, 8, 34, 4, 185, DateTimeKind.Local).AddTicks(2920));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 26, 8, 34, 4, 185, DateTimeKind.Local).AddTicks(2920));
        }
    }
}
