using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_App.Migrations
{
    /// <inheritdoc />
    public partial class updateorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductPrice = table.Column<double>(type: "float", nullable: false),
                    ProductUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDiscount = table.Column<double>(type: "float", nullable: true),
                    OrderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f98b7e36-cfe5-4b58-99da-ad1197a176ba", "AQAAAAIAAYagAAAAEFfts4DsVvxxeGJoEVEDuIFlnnZN6wy/oSxT7HO8z7HMGr8zgMCu7MqG4VzgROWWIg==", "f42f8157-2ded-493b-a8b5-9cf4151ed0e0" });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_OrderID",
                table: "ShoppingCartItem",
                column: "OrderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItem");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "812f2145-5c1b-49d8-82f7-cb08abe97527", "AQAAAAIAAYagAAAAECV5FwFnk6oQh/qdKfZMzB6mgEOqbwUFacYNrsOn09KdtrCbEbI1Qz73F6y+W43Eag==", "1901027c-5f57-4f11-9d77-54350abc6573" });
        }
    }
}
