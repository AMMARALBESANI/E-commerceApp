using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_App.Migrations
{
    /// <inheritdoc />
    public partial class updatesomethings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ShoppingCartItem",
                newName: "username");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f039b93-f93e-46fb-bce6-95407e3446ca", "AQAAAAIAAYagAAAAEHEgOTSvaQH6CeP/2AIcK62TOdC63a4cULzHvtEga0YCIpDea+u1UROPp9Al/bpAXA==", "3ebf249c-53b2-40c0-8f97-4bbebb951860" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "ShoppingCartItem",
                newName: "UserId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f979d5d-bea1-44ae-a966-300a30a51c0a", "AQAAAAIAAYagAAAAELTMBR5e5UVcSf+eTcfle+8v5Ms64gl+JNKjpOrsCM/SwgbZOqqUgOtf+db2ragRnQ==", "9b29c0d5-8057-4d32-972f-e60aaf4128aa" });
        }
    }
}
