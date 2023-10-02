using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_App.Migrations
{
    /// <inheritdoc />
    public partial class asdasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentStatus",
                table: "Orders",
                newName: "Status");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aebd7078-41b9-4d70-9383-6e45e3fd45d9", "AQAAAAIAAYagAAAAEGJ2AQ6IXzcFBGsBvdI+DrD134IU9SR2+vIZ/oN+ogIEViM0gTGvcWx+W3GzARt04g==", "0e0e30bb-8c6a-4de5-945c-3c75343d5e26" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Orders",
                newName: "PaymentStatus");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abff8a16-3a8a-4de8-bc06-499c6363858b", "AQAAAAIAAYagAAAAEIHFRePg8OSC/NZYQMpCQz8Ubmu7Gahg/8+F5OUyUIEvaZN2y8igDoe1WZOWJGSR3A==", "b416c2ed-f204-493d-a923-fa7f23e0e996" });
        }
    }
}
