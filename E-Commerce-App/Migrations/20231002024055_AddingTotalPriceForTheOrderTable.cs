using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_App.Migrations
{
    /// <inheritdoc />
    public partial class AddingTotalPriceForTheOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3dd6824e-029e-4cd6-8da8-a8776c901f3e", "AQAAAAIAAYagAAAAEA8gyKxS2E5JxHsqgcL/Kzl3KwusCiqlacTdm9f5Vd5Viz1MD47lByGKMghihN3/sQ==", "3b5ac089-a365-4d40-b2a8-9c67b8b4fff0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aebd7078-41b9-4d70-9383-6e45e3fd45d9", "AQAAAAIAAYagAAAAEGJ2AQ6IXzcFBGsBvdI+DrD134IU9SR2+vIZ/oN+ogIEViM0gTGvcWx+W3GzARt04g==", "0e0e30bb-8c6a-4de5-945c-3c75343d5e26" });
        }
    }
}
