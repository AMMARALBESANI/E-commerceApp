using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_App.Migrations
{
    /// <inheritdoc />
    public partial class updateshoppinglist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShoppingCartItem",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f979d5d-bea1-44ae-a966-300a30a51c0a", "AQAAAAIAAYagAAAAELTMBR5e5UVcSf+eTcfle+8v5Ms64gl+JNKjpOrsCM/SwgbZOqqUgOtf+db2ragRnQ==", "9b29c0d5-8057-4d32-972f-e60aaf4128aa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShoppingCartItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f98b7e36-cfe5-4b58-99da-ad1197a176ba", "AQAAAAIAAYagAAAAEFfts4DsVvxxeGJoEVEDuIFlnnZN6wy/oSxT7HO8z7HMGr8zgMCu7MqG4VzgROWWIg==", "f42f8157-2ded-493b-a8b5-9cf4151ed0e0" });
        }
    }
}
