using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetInventory.Api.Migrations
{
    /// <inheritdoc />
    public partial class DeleteUpdateBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateBy",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "Categories",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 16, 25, 25, 453, DateTimeKind.Local).AddTicks(280));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 16, 25, 25, 453, DateTimeKind.Local).AddTicks(470));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 16, 25, 25, 453, DateTimeKind.Local).AddTicks(480));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 1, 20, 16, 25, 25, 453, DateTimeKind.Local).AddTicks(480));
        }
    }
}
