using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_App.Migrations
{
    /// <inheritdoc />
    public partial class anything : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PaymentStatus",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abff8a16-3a8a-4de8-bc06-499c6363858b", "AQAAAAIAAYagAAAAEIHFRePg8OSC/NZYQMpCQz8Ubmu7Gahg/8+F5OUyUIEvaZN2y8igDoe1WZOWJGSR3A==", "b416c2ed-f204-493d-a923-fa7f23e0e996" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PaymentStatus",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bccfc89f-e1d0-4bd2-a482-1a046fda8af9", "AQAAAAIAAYagAAAAEIhqtXvK5lL034WxOP0Xxn5CgTtb3dW/IH1rP5lqH3E42sjRZZPqVENm8K72GbsRvw==", "79d31160-9e0c-4cac-b0eb-b64901ae6288" });
        }
    }
}
