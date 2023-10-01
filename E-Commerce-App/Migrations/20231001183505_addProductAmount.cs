using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_App.Migrations
{
    /// <inheritdoc />
    public partial class addProductAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b510bbad-c572-4e4f-aabc-2fe222500814", "AQAAAAIAAYagAAAAEDLWLueA4b2lZ+L9z9YXyB+7m6XV1Lho4gpzsa53yrVt3cZWj7Y1S3Z9wnNbsrL2YA==", "2104caf7-b710-47fd-bc54-ce20d13eeac5" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 1,
                column: "Amount",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 2,
                column: "Amount",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 3,
                column: "Amount",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 4,
                column: "Amount",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 5,
                column: "Amount",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 6,
                column: "Amount",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 7,
                column: "Amount",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 8,
                column: "Amount",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 9,
                column: "Amount",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 10,
                column: "Amount",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 11,
                column: "Amount",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 12,
                column: "Amount",
                value: 25);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25017dc3-f039-4a44-8660-8d8053a4ba5a", "AQAAAAIAAYagAAAAED9aHAaSJsHdZDgrmFzs6BYNsU7bf/TaJIQUGV9xoDkfxuWwHWlAdrWuOAoPCRi/Qw==", "e41979f5-b5ea-41d2-85c0-2c10eea227a9" });
        }
    }
}
