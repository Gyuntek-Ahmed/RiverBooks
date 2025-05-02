using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RiverBooks.Books.Data.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0d35d8b6-3958-49e5-a9cb-7ce868303e84"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("303d9a8a-f308-4359-ab05-df603b1b3b09"));

            migrationBuilder.DeleteData(
                schema: "Books",
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("cc3b29e8-3e6a-42ee-9bd3-e5fdaf54a0f8"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("0d35d8b6-3958-49e5-a9cb-7ce868303e84"), "J.R.R. Tolkien", 19.99m, "The Silmarillion" },
                    { new Guid("303d9a8a-f308-4359-ab05-df603b1b3b09"), "J.R.R. Tolkien", 10.99m, "The Hobbit" },
                    { new Guid("cc3b29e8-3e6a-42ee-9bd3-e5fdaf54a0f8"), "J.R.R. Tolkien", 29.99m, "The Lord of the Rings" }
                });
        }
    }
}
