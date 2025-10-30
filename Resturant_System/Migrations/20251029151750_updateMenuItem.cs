using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_System.Migrations
{
    /// <inheritdoc />
    public partial class updateMenuItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailableQuantity",
                table: "MenuItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DailyLimit",
                table: "MenuItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableQuantity", "DailyLimit", "LastUpdated" },
                values: new object[] { 50, 50, new DateTime(2025, 10, 29, 18, 17, 46, 437, DateTimeKind.Local).AddTicks(6666) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableQuantity", "DailyLimit", "LastUpdated" },
                values: new object[] { 50, 50, new DateTime(2025, 10, 29, 18, 17, 46, 437, DateTimeKind.Local).AddTicks(6723) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableQuantity", "DailyLimit", "LastUpdated" },
                values: new object[] { 50, 50, new DateTime(2025, 10, 29, 18, 17, 46, 437, DateTimeKind.Local).AddTicks(6727) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableQuantity", "DailyLimit", "LastUpdated" },
                values: new object[] { 50, 50, new DateTime(2025, 10, 29, 18, 17, 46, 437, DateTimeKind.Local).AddTicks(6730) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AvailableQuantity", "DailyLimit", "LastUpdated" },
                values: new object[] { 50, 50, new DateTime(2025, 10, 29, 18, 17, 46, 437, DateTimeKind.Local).AddTicks(6734) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AvailableQuantity", "DailyLimit", "LastUpdated" },
                values: new object[] { 50, 50, new DateTime(2025, 10, 29, 18, 17, 46, 437, DateTimeKind.Local).AddTicks(6737) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AvailableQuantity", "DailyLimit", "LastUpdated" },
                values: new object[] { 50, 50, new DateTime(2025, 10, 29, 18, 17, 46, 437, DateTimeKind.Local).AddTicks(6740) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AvailableQuantity", "DailyLimit", "LastUpdated" },
                values: new object[] { 50, 50, new DateTime(2025, 10, 29, 18, 17, 46, 437, DateTimeKind.Local).AddTicks(6743) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AvailableQuantity", "DailyLimit", "LastUpdated" },
                values: new object[] { 50, 50, new DateTime(2025, 10, 29, 18, 17, 46, 437, DateTimeKind.Local).AddTicks(6746) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AvailableQuantity", "DailyLimit", "LastUpdated" },
                values: new object[] { 50, 50, new DateTime(2025, 10, 29, 18, 17, 46, 437, DateTimeKind.Local).AddTicks(6748) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AvailableQuantity", "DailyLimit", "LastUpdated" },
                values: new object[] { 50, 50, new DateTime(2025, 10, 29, 18, 17, 46, 437, DateTimeKind.Local).AddTicks(6751) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AvailableQuantity", "DailyLimit", "LastUpdated" },
                values: new object[] { 50, 50, new DateTime(2025, 10, 29, 18, 17, 46, 437, DateTimeKind.Local).AddTicks(6754) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AvailableQuantity", "DailyLimit", "LastUpdated" },
                values: new object[] { 50, 50, new DateTime(2025, 10, 29, 18, 17, 46, 437, DateTimeKind.Local).AddTicks(6757) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AvailableQuantity", "DailyLimit", "LastUpdated" },
                values: new object[] { 50, 50, new DateTime(2025, 10, 29, 18, 17, 46, 437, DateTimeKind.Local).AddTicks(6760) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AvailableQuantity", "DailyLimit", "LastUpdated" },
                values: new object[] { 50, 50, new DateTime(2025, 10, 29, 18, 17, 46, 437, DateTimeKind.Local).AddTicks(6762) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AvailableQuantity", "DailyLimit", "LastUpdated" },
                values: new object[] { 50, 50, new DateTime(2025, 10, 29, 18, 17, 46, 437, DateTimeKind.Local).AddTicks(6766) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableQuantity",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "DailyLimit",
                table: "MenuItems");

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
    }
}
