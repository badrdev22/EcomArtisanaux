using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artisanaux.Service.ProductAPI.Migrations
{
    public partial class seeds_store : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "CategoryName", "ImageURL", "Price", "ProductName" },
                values: new object[] { 1, "Category 1", "http://lorempixel.com/640/480/technics/1", 1232.0, "Product 1" });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "CategoryName", "ImageURL", "Price", "ProductName" },
                values: new object[] { 2, "Category 2", "http://lorempixel.com/640/480/technics/2", 1232.0, "Product 2" });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "CategoryName", "ImageURL", "Price", "ProductName" },
                values: new object[] { 3, "Category 3", "http://lorempixel.com/640/480/technics/3", 1232.0, "Product 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "ProductId",
                keyValue: 3);
        }
    }
}
