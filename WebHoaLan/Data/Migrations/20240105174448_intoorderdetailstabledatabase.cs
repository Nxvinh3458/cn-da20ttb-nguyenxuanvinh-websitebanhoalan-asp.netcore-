using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHoaLan.Data.Migrations
{
    public partial class intoorderdetailstabledatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_PorductId",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "PorductId",
                table: "OrderDetails",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_PorductId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductsId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderDetails",
                newName: "PorductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_PorductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_PorductId",
                table: "OrderDetails",
                column: "PorductId",
                principalTable: "Products",
                principalColumn: "ProductsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
