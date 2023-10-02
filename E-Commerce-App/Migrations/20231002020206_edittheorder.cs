using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_App.Migrations
{
    /// <inheritdoc />
    public partial class edittheorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_Orders_OrderID",
                table: "ShoppingCartItem");

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                table: "ShoppingCartItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SessionID",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bccfc89f-e1d0-4bd2-a482-1a046fda8af9", "AQAAAAIAAYagAAAAEIhqtXvK5lL034WxOP0Xxn5CgTtb3dW/IH1rP5lqH3E42sjRZZPqVENm8K72GbsRvw==", "79d31160-9e0c-4cac-b0eb-b64901ae6288" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_Orders_OrderID",
                table: "ShoppingCartItem",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_Orders_OrderID",
                table: "ShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SessionID",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                table: "ShoppingCartItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f039b93-f93e-46fb-bce6-95407e3446ca", "AQAAAAIAAYagAAAAEHEgOTSvaQH6CeP/2AIcK62TOdC63a4cULzHvtEga0YCIpDea+u1UROPp9Al/bpAXA==", "3ebf249c-53b2-40c0-8f97-4bbebb951860" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_Orders_OrderID",
                table: "ShoppingCartItem",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID");
        }
    }
}
