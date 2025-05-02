using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RiverBooks.Books.Data.Migrations
{
    /// <inheritdoc />
    public partial class Thirtd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("137cea4e-334c-4841-9a5c-776487084423"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("666c8c03-7891-43e4-8da7-d803569e7aba"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("6d15efde-a7e0-4a51-a942-c7b431a390d1"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("d736edba-562d-4857-8215-a5db699a0180"));

            migrationBuilder.InsertData(
                schema: "Books",
                table: "Books",
                columns: new[] { "Id", "Author", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("5f7827d3-ddb9-42fe-9670-42c971f49a37"), "J.R.R. Tolkien", 19.99m, "The Silmarillion" },
                    { new Guid("ac76deab-e2c4-4726-a244-3288ae9f4244"), "J.R.R. Tolkien", 10.99m, "The Hobbit" },
                    { new Guid("ddbde630-efcc-4a88-a9a1-6000355c13bc"), "J.R.R. Tolkien", 29.99m, "The Lord of the Rings" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5f7827d3-ddb9-42fe-9670-42c971f49a37"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ac76deab-e2c4-4726-a244-3288ae9f4244"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ddbde630-efcc-4a88-a9a1-6000355c13bc"));

            migrationBuilder.InsertData(
                schema: "Books",
                table: "Books",
                columns: new[] { "Id", "Author", "Price", "Title" },
                values: new object[,]
                {
                    { new Guid("137cea4e-334c-4841-9a5c-776487084423"), "J.R.R. Tolkien", 14.99m, "The Children of Húrin" },
                    { new Guid("666c8c03-7891-43e4-8da7-d803569e7aba"), "J.R.R. Tolkien", 19.99m, "The Silmarillion" },
                    { new Guid("6d15efde-a7e0-4a51-a942-c7b431a390d1"), "J.R.R. Tolkien", 10.99m, "The Hobbit" },
                    { new Guid("d736edba-562d-4857-8215-a5db699a0180"), "J.R.R. Tolkien", 29.99m, "The Lord of the Rings" }
                });
        }
    }
}
