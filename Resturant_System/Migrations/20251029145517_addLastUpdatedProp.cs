using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_System.Migrations
{
    /// <inheritdoc />
    public partial class addLastUpdatedProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "MenuItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2025, 10, 29, 17, 55, 13, 132, DateTimeKind.Local).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2025, 10, 29, 17, 55, 13, 132, DateTimeKind.Local).AddTicks(4933));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2025, 10, 29, 17, 55, 13, 132, DateTimeKind.Local).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastUpdated",
                value: new DateTime(2025, 10, 29, 17, 55, 13, 132, DateTimeKind.Local).AddTicks(4941));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastUpdated",
                value: new DateTime(2025, 10, 29, 17, 55, 13, 132, DateTimeKind.Local).AddTicks(4943));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastUpdated",
                value: new DateTime(2025, 10, 29, 17, 55, 13, 132, DateTimeKind.Local).AddTicks(4947));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastUpdated",
                value: new DateTime(2025, 10, 29, 17, 55, 13, 132, DateTimeKind.Local).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastUpdated",
                value: new DateTime(2025, 10, 29, 17, 55, 13, 132, DateTimeKind.Local).AddTicks(4953));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastUpdated",
                value: new DateTime(2025, 10, 29, 17, 55, 13, 132, DateTimeKind.Local).AddTicks(4956));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastUpdated",
                value: new DateTime(2025, 10, 29, 17, 55, 13, 132, DateTimeKind.Local).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastUpdated",
                value: new DateTime(2025, 10, 29, 17, 55, 13, 132, DateTimeKind.Local).AddTicks(4961));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastUpdated",
                value: new DateTime(2025, 10, 29, 17, 55, 13, 132, DateTimeKind.Local).AddTicks(4964));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastUpdated",
                value: new DateTime(2025, 10, 29, 17, 55, 13, 132, DateTimeKind.Local).AddTicks(4967));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastUpdated",
                value: new DateTime(2025, 10, 29, 17, 55, 13, 132, DateTimeKind.Local).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastUpdated",
                value: new DateTime(2025, 10, 29, 17, 55, 13, 132, DateTimeKind.Local).AddTicks(4972));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastUpdated",
                value: new DateTime(2025, 10, 29, 17, 55, 13, 132, DateTimeKind.Local).AddTicks(4975));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "MenuItems");
        }
    }
}
