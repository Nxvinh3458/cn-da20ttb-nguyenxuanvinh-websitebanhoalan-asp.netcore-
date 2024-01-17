using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHoaLan.Data.Migrations
{
    public partial class intoproductstabledatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SpecialTags",
                newName: "SpecialTagName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SpecialTags",
                newName: "SpecialTagId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductTypes",
                newName: "ProductTypesId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "ProductsName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductsId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrderDetails",
                newName: "OrderDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpecialTagName",
                table: "SpecialTags",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "SpecialTagId",
                table: "SpecialTags",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductTypesId",
                table: "ProductTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductsName",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OrderDetailsId",
                table: "OrderDetails",
                newName: "Id");
        }
    }
}
